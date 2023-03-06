// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.AppMagic.Authoring.Persistence;
using Microsoft.PowerPlatform.Formulas.Tools.EditorState;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Microsoft.PowerPlatform.Formulas.Tools.ControlTemplates
{
    internal class ControlTemplateParser
    {
        internal static Regex _reservedIdentifierRegex = new Regex(@"%([a-zA-Z]*)\.RESERVED%");


        internal static bool TryParseTemplate(TemplateStore templateStore, string templateString, AppType type, Dictionary<string, ControlTemplate> loadedTemplates, out ControlTemplate template, out string name)
        {
            template = null;
            name = string.Empty;
            try
            {
                var manifest = XDocument.Parse(templateString);
                if (manifest == null)
                    return false;
                var widget = manifest.Root;
                if (widget.Name != ControlMetadataXNames.WidgetTag)
                    return false;

                name = widget.Attribute(ControlMetadataXNames.NameAttribute).Value;
                var id = widget.Attribute(ControlMetadataXNames.IdAttribute).Value;
                var version = widget.Attribute(ControlMetadataXNames.VersionAttribute).Value;

                template = new ControlTemplate(name, version, id);

                var properties = widget.Element(ControlMetadataXNames.PropertiesTag);
                if (properties != null)
                {
                    foreach (var prop in properties.Elements(ControlMetadataXNames.PropertyTag))
                    {
                        if (prop.Attribute(ControlMetadataXNames.DirectionAttribute)?.Value == "out")
                            continue;
                        if (!AddPropertyDefault(prop, type, template))
                            return false;
                    }
                }

                // Parse the include properties and add them to control template
                var includeProperties = widget.Element(ControlMetadataXNames.IncludePropertiesTag);
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties.Elements(ControlMetadataXNames.IncludePropertyTag))
                    {
                        if (includeProperty.Attribute(ControlMetadataXNames.DirectionAttribute)?.Value == "out")
                            continue;
                        AddIncludePropertyDefault(includeProperty, type, template);
                    }
                }

                if (template.Id == "http://microsoft.com/appmagic/gallery" && !TryParseNestedWidgets(templateStore, widget, type, loadedTemplates))
                    return false;

                loadedTemplates.Add(name, template);
                if (!templateStore.TryGetTemplate(name, out _))
                {
                    templateStore.AddTemplate(name, new CombinedTemplateState()
                    {
                        Id = template.Id,
                        Name = template.Name,
                        Version = template.Version,
                        LastModifiedTimestamp = "0",
                        IsComponentTemplate = false,
                        FirstParty = true,
                    });
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool TryParseNestedWidgets(TemplateStore templateStore, XElement root, AppType type, Dictionary<string, ControlTemplate> loadedTemplates)
        {
            var nestedWidgets = root.Element(ControlMetadataXNames.NestedWidgets);
            if (nestedWidgets == null)
                return false;

            foreach (var widget in nestedWidgets.Elements(ControlMetadataXNames.DataControlWidgetTag))
            {
                var name = widget.Attribute(ControlMetadataXNames.NameAttribute).Value;
                var id = widget.Attribute(ControlMetadataXNames.IdAttribute).Value;
                var version = widget.Attribute(ControlMetadataXNames.VersionAttribute).Value;

                var template = new ControlTemplate(name, version, id);

                var properties = widget.Element(ControlMetadataXNames.PropertiesTag);
                if (properties != null)
                {
                    foreach (var prop in properties.Elements(ControlMetadataXNames.PropertyTag))
                    {
                        if (prop.Attribute(ControlMetadataXNames.DirectionAttribute)?.Value == "out")
                            continue;

                        if (!AddPropertyDefault(prop, type, template))
                            return false;
                    }
                }

                loadedTemplates.Add(name, template);
                if (!templateStore.TryGetTemplate(name, out _))
                {
                    templateStore.AddTemplate(name, new CombinedTemplateState()
                    {
                        Id = template.Id,
                        Name = template.Name,
                        Version = template.Version,
                        LastModifiedTimestamp = "0",
                        IsComponentTemplate = false,
                        FirstParty = true,
                    });
                }
            }
            return true;
        }

        private static bool AddPropertyDefault(XElement prop, AppType type, ControlTemplate template)
        {
            var ctrlProp = ParseProperty(prop);
            if (ctrlProp == null)
                return false;
            template.InputDefaults.Add(ctrlProp.Name, ctrlProp.GetDefaultValue(type) ?? string.Empty);
            return true;
        }

        private static void AddIncludePropertyDefault(XElement includeProperty, AppType type, ControlTemplate template)
        {
            var propertyName = includeProperty.Attribute(ControlMetadataXNames.NameAttribute).Value;
            // Explicitly defined props overwrite common props
            if (template.InputDefaults.ContainsKey(propertyName))
                return;

            var defaultOverride = includeProperty.Attribute(ControlMetadataXNames.DefaultValueAttribute);
            if (defaultOverride != null)
                template.InputDefaults.Add(propertyName, UnescapeReservedName(defaultOverride.Value));
            else 
                template.InputDefaults.Add(propertyName, CommonControlProperties.Instance.GetDefaultValue(propertyName, type) ?? string.Empty);
        }


        internal static ControlProperty ParseProperty(XElement property)
        {
            var nameAttr = property.Attribute(ControlMetadataXNames.NameAttribute);
            if (nameAttr == null)
                return null;

            string defaultValue = null;
            string phoneDefaultValue = null;
            string webDefaultValue = null;

            var defaultValueAttrib = property.Attribute(ControlMetadataXNames.DefaultValueAttribute);
            if (defaultValueAttrib != null)
                defaultValue = UnescapeReservedName(defaultValueAttrib.Value);

            var phoneDefaultValueAttrib = property.Attribute(ControlMetadataXNames.PhoneDefaultValueAttribute);
            if (phoneDefaultValueAttrib != null)
                phoneDefaultValue = UnescapeReservedName(phoneDefaultValueAttrib.Value);

            var webDefaultValueAttrib = property.Attribute(ControlMetadataXNames.WebDefaultValueAttribute);
            if (webDefaultValueAttrib != null)
                webDefaultValue = UnescapeReservedName(webDefaultValueAttrib.Value);

            return new ControlProperty(nameAttr.Value, defaultValue, phoneDefaultValue, webDefaultValue);
        }

        internal static string UnescapeReservedName(string expression)
        {
            return _reservedIdentifierRegex.Replace(expression, "$1");
        }
    }
}