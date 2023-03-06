using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System;

namespace Net.Formulas.Tools.Classes
{

    public class AppPreviewFlagsMap
    {
        public bool delayloadscreens { get; set; }
        public bool errorhandling { get; set; }
        public bool enableappembeddingux { get; set; }
        public bool blockmovingcontrol { get; set; }
        public bool projectionmapping { get; set; }
        public bool usedisplaynamemetadata { get; set; }
        public bool usenonblockingonstartrule { get; set; }
        public bool longlivingcache { get; set; }
        public bool useguiddatatypes { get; set; }
        public bool useexperimentalcdsconnector { get; set; }
        public bool useenforcesavedatalimits { get; set; }
        public bool webbarcodescanner { get; set; }
        public bool componentauthoring { get; set; }
        public bool reliableconcurrent { get; set; }
        public bool parallelcodegen { get; set; }
        public bool datatablev2control { get; set; }
        public bool nativecdsexperimental { get; set; }
        public bool reactformulabar { get; set; }
        public bool delaycontrolrendering { get; set; }
        public bool useexperimentalsqlconnector { get; set; }
        public bool disablecdsfileandlargeimage { get; set; }
        public bool formuladataprefetch { get; set; }
        public bool enablerulespanel { get; set; }
        public bool enhanceddelegation { get; set; }
        public bool generatedebugpublishedapp { get; set; }
        public bool keeprecentscreensloaded { get; set; }
        public bool aibuilderserviceenrollment { get; set; }
        public bool enableaimodelsindatapane { get; set; }
        public bool dynamicschema { get; set; }
        public bool enablerowscopeonetonexpand { get; set; }
        public bool herocontrols { get; set; }
        public bool classiccontrols { get; set; }
        public bool enablepcfmoderndatasets { get; set; }
        public bool improvedmediacapture { get; set; }
        public bool optimizedforteamsmeeting { get; set; }
        public bool behaviorpropertyui { get; set; }
        public bool autocreateenvironmentvariables { get; set; }
        public bool externalmessage { get; set; }
        public bool enhancedgalleryinitialization { get; set; }
        public bool backfromhostaction { get; set; }
        public bool enableonstartnavigate { get; set; }
        public bool enableexcelonlinebusinessv2connector { get; set; }
        public bool enableonstart { get; set; }
        public bool exportimportcomponents2 { get; set; }
        public bool copyandmerge { get; set; }
        public bool allowmultiplescreensincanvaspages { get; set; }
        public bool enablecomponentscopeoldbehavior { get; set; }
        public bool enableideaspanel { get; set; }
        public bool enablesaveloadcleardataonweb { get; set; }
        public bool enablepowerautomatepane { get; set; }

    }
    public class ControlCount
    {
        public int screen { get; set; }

    }
    public class MsappProperties
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string FileID { get; set; }
        public string LocalConnectionReferences { get; set; }
        public string LocalDatabaseReferences { get; set; }
        public string LibraryDependencies { get; set; }
        public AppPreviewFlagsMap AppPreviewFlagsMap { get; set; }
        public int DocumentLayoutWidth { get; set; }
        public int DocumentLayoutHeight { get; set; }
        public string DocumentLayoutOrientation { get; set; }
        public bool DocumentLayoutScaleToFit { get; set; }
        public bool DocumentLayoutMaintainAspectRatio { get; set; }
        public bool DocumentLayoutLockOrientation { get; set; }
        public string OriginatingVersion { get; set; }
        public string DocumentAppType { get; set; }
        public string DocumentType { get; set; }
        public string AppCreationSource { get; set; }
        public string AppDescription { get; set; }
        public int DefaultConnectedDataSourceMaxGetRowsCount { get; set; }
        public bool ContainsThirdPartyPcfControls { get; set; }
        public int ErrorCount { get; set; }
        public string InstrumentationKey { get; set; }
        public bool EnableInstrumentation { get; set; }
        public ControlCount ControlCount { get; set; }
        public double DeserializationLoadTime { get; set; }
        public double AnalysisLoadTime { get; set; }

    }

    public partial class PublishInfo
    {
        public string AppName { get; set; }

        public string BackgroundColor { get; set; }

        public string PublishTarget { get; set; }

        public string LogoFileName { get; set; }

        public string IconColor { get; set; }

        public string IconName { get; set; }

        public bool PublishResourcesLocally { get; set; }

        public bool PublishDataLocally { get; set; }

        public string UserLocale { get; set; }
    }
    class OneFile
    {
        public string NameFile { get; set; }
        public string FileContent { get; set; }

        public OneFile(string NvName, string NvContent)
        {
            this.NameFile = NvName;
            this.FileContent = NvContent;
        }
    }

    class MsappLoader
    {

        public List<OneFile> collAppMiscComponents;

        public List<OneFile> collAppAssets;

        public List<OneFile> collAppControls;

        public List<OneFile> collAppComponents;

        public List<OneFile> collAppReferences;

        public List<OneFile> collAppResources;

        /// <summary>
        /// Parse MsApp file to collection
        /// </summary>
        /// <param name="StreamZip">msapp stream</param>
        public MsappLoader(MemoryStream StreamZip)
        {
            collAppMiscComponents = new List<OneFile>();
            collAppAssets = new List<OneFile>();
            collAppControls = new List<OneFile>();
            collAppComponents = new List<OneFile>();
            collAppReferences = new List<OneFile>();
            collAppResources = new List<OneFile>();

            using (ZipArchive archive = new ZipArchive(StreamZip, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.Contains("Assets/"))
                    {
                        this.collAppAssets.Add(new OneFile(entry.Name, MsappLoader.ReadEntryToTheEnd(entry)));
                    }
                    else if (entry.FullName.Contains("Components\\"))
                    {
                        this.collAppComponents.Add(new OneFile(entry.Name, MsappLoader.ReadEntryToTheEnd(entry)));
                    }
                    else if (entry.FullName.Contains("Controls\\"))
                    {
                        this.collAppControls.Add(new OneFile(entry.Name, MsappLoader.ReadEntryToTheEnd(entry)));
                    }
                    else if (entry.FullName.Contains("References\\"))
                    {
                        this.collAppReferences.Add(new OneFile(entry.Name, MsappLoader.ReadEntryToTheEnd(entry)));
                    }
                    else if (entry.FullName.Contains("Resources\\"))
                    {
                        this.collAppResources.Add(new OneFile(entry.Name, MsappLoader.ReadEntryToTheEnd(entry)));
                    }
                    else if (entry.FullName == "Properties.json")
                    {
                        this.collAppResources.Add(new OneFile(entry.Name, MsappLoader.ReadEntryToTheEnd(entry)));
                    }
                    else
                    {
                        this.collAppMiscComponents.Add(new OneFile(entry.Name, MsappLoader.ReadEntryToTheEnd(entry)));
                    }
                }
            }
        }

        public static string ReadEntryToTheEnd(ZipArchiveEntry Entry)
        {
            using (var stream = Entry.Open())
            using (var reader = new StreamReader(stream))
            {
                return (reader.ReadToEnd());
            }
        }

        public PublishInfo SerialisePublishInfos()
        {
            PublishInfo MsappInfos;
            try
            {
                if (this.collAppResources.Where(x => x.NameFile == "PublishInfo.json").ToList().Count() > 0)
                {
                    string PublishInfoTxt = this.collAppResources.Where(x => x.NameFile == "PublishInfo.json").First().FileContent;
                    MsappInfos = JsonSerializer.Deserialize<PublishInfo>(PublishInfoTxt);
                    return MsappInfos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public MsappProperties SerialiseProperty()
        {
            MsappProperties MsappProperty = null;
            try
            {
                string PropertyTxt;
                foreach (OneFile resource in this.collAppResources)
                {
                    if (resource.NameFile == "Properties.json")
                    {
                        PropertyTxt = resource.FileContent;
                        MsappProperty = JsonSerializer.Deserialize<MsappProperties>(PropertyTxt);
                    }
                }

                return MsappProperty;


                /*if (this.collAppResources.Where(x => x.NameFile == "Properties.json").ToList().Count() > 0)
                {
                    string PropertyTxt = this.collAppResources.Where(x => x.NameFile.Contains("Properties.json")).First().FileContent;
                    MsappProperty = JsonSerializer.Deserialize<MsappProperties>(PropertyTxt);
                    return MsappProperty;
                }
                else
                {
                    return null;
                }*/
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}