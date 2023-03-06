using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.IO.Compression;
using Net.Formulas.Tools.Classes;
using System.Xml;
using Microsoft.Xrm.Sdk;

namespace Net.Formulas.Tools.Solution
{
    public class PowerAutomate
    {
        public string NomPowerAutomate { get; set; }
        public string CodePowerAutomate { get; set; }
        public PowerAutomate(string NvNomPowerAutomate, string NvCodePowerAutomate)
        {
            this.NomPowerAutomate = NvNomPowerAutomate;
            this.CodePowerAutomate = NvCodePowerAutomate;
        }
    }

    public class PowerApps
    {
        public string NomPowerApps { get; set; }

        public string TypeApp { get; set; }
        public string NomPowerAppsFichier { get; set; }
        public Stream ContenuFichier { get; set; }

        public PowerApps(string NvNomPowerAppsFile, string NvNomPowerApps, MemoryStream NvContenuFichier, string TypedeFichier)
        {
            this.NomPowerApps = NvNomPowerApps;
            this.NomPowerAppsFichier = NvNomPowerAppsFile;
            this.ContenuFichier = NvContenuFichier;
            this.TypeApp = TypedeFichier;
        }
    }

    public class FileWebRessource
    {
        public string NomRessource { get; set; }
        public int Taille { get; set; }
        public FileWebRessource(string NvNomRessource, int NvTaille)
        {
            this.NomRessource = NvNomRessource;
            this.Taille = NvTaille;
        }
    }

    public class EnvVariable
    {
        public string NomVariable { get; set; }
        public string ValeurVariable { get; set; }

        public EnvVariable(string NvNom, string NvValeurVariable)
        {
            this.NomVariable = NvNom;
            this.ValeurVariable = NvValeurVariable;
        }
    }

    public class EnvFormulas
    {
        public string NomFormule { get; set; }
        public string ValeurFormule { get; set; }

        public EnvFormulas(string NvNom, string NvValeurFormule)
        {
            this.NomFormule = NvNom;
            this.ValeurFormule = NvValeurFormule;
        }
    }

    public class AppContainer
    {
        public string NomContainer { get; set; }

        public List<PowerApps> SubApps { get; set; }

        public AppContainer(string NvNomContainer, List<PowerApps> NvSubApps)
        {
            this.NomContainer = NvNomContainer;

            this.SubApps = NvSubApps;

        }

        public AppContainer(string NvNomContainer)
        {
            this.NomContainer = NvNomContainer;
            this.SubApps = new List<PowerApps>();
        }

        public void AddApp(PowerApps OneApp)
        {
            this.SubApps.Add(OneApp);
        }
    }

    class SolutionLoader
    {
        public List<AppContainer> AppOrganisations { get; set; }
        public ImportExportXml MyExportXml { get; set; }
        public string ContenuFichierSolution { get; set; }
        public string ContenuFichierContenType { get; set; }
        public string ContenuFichierCustomisation { get; set; }

        public List<PowerApps> ListApps { get; set; }

        public List<PowerAutomate> ListFlows { get; set; }

        public List<FileWebRessource> ListRessources { get; set; }
        public List<EnvVariable> ListVariables { get; set; }
        public List<EnvFormulas> ListFormulas { get; set; }

        public ImportExportXml DeserialiseCustomizations(string XmlText)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportExportXml));
            StringReader reader = new StringReader(XmlText);
            ImportExportXml ElementsXml = (ImportExportXml)serializer.Deserialize(reader);

            return ElementsXml;
        }

        public ImportExportXml DeserializeEntries(string XmlText)
        {
            try
            {
                var settings = new XmlReaderSettings
                {
                    // Allow processing of DTD
                    DtdProcessing = DtdProcessing.Parse,
                    // On older versions of .Net instead set 
                    //ProhibitDtd = false,
                    // But for security, prevent DOS attacks by limiting the total number of characters that can be expanded to something sane.
                    MaxCharactersFromEntities = (long)1e7,
                    // And for security, disable resolution of entities from external documents.
                    XmlResolver = null,
                };

                StringReader reader = new StringReader(XmlText);

                using (var xmlReader = XmlReader.Create(reader, settings))
                {
                    var serializer = new XmlSerializer(typeof(ImportExportXml));
                    return (ImportExportXml)serializer.Deserialize(xmlReader);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Parse either Solution or MsApp file and read components
        /// </summary>
        /// <param name="StreamZip">Solution file or msapp file stream</param>
        /// <param name="typeImport"> Type of Import</param>
        /// <param name="PowerAppsFileName">Power Apps File Name</param>
        /// <param name="tracingService">Tracing Service</param>
        public SolutionLoader(MemoryStream StreamZip, string typeImport, string PowerAppsFileName = "", ITracingService tracingService = null)
        {
            this.AppOrganisations = new List<AppContainer>();
            this.ListFlows = new List<PowerAutomate>();
            this.ListApps = new List<PowerApps>();
            this.ListRessources = new List<FileWebRessource>();
            this.ListVariables = new List<EnvVariable>();
            this.ListFormulas = new List<EnvFormulas>();
            MemoryStream MemStream;
            Stream MsappStream;

            if (tracingService != null) tracingService.Trace($"typeImport : {typeImport}");
            try
            {
                if (typeImport.ToLowerInvariant() == "solution")
                {
                    using (ZipArchive archive = new ZipArchive(StreamZip, ZipArchiveMode.Read))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.FullName.EndsWith("solution.xml", StringComparison.OrdinalIgnoreCase))
                            {
                                this.ContenuFichierSolution = SolutionLoader.ReadEntryToTheEnd(entry);
                            }
                            else if (entry.FullName.EndsWith("[Content_Types].xml", StringComparison.OrdinalIgnoreCase))
                            {
                                this.ContenuFichierSolution = SolutionLoader.ReadEntryToTheEnd(entry);
                            }
                            else if (entry.FullName.EndsWith("customizations.xml", StringComparison.OrdinalIgnoreCase))
                            {
                                this.ContenuFichierCustomisation = SolutionLoader.ReadEntryToTheEnd(entry);
                                this.MyExportXml = DeserializeEntries(this.ContenuFichierCustomisation);
                            }
                            else if (entry.FullName.Contains("CanvasApps/") && entry.FullName.EndsWith("msapp"))
                            {
                                using (MsappStream = entry.Open())
                                {
                                    MemStream = new MemoryStream();
                                    MsappStream.CopyTo(MemStream);

                                    MemStream.Position = 0;

                                    MsappLoader MyAppLoader = new MsappLoader(MemStream);
                                    MemStream = new MemoryStream();
                                    MsappStream = entry.Open();
                                    MsappStream.CopyTo(MemStream);

                                    MsappProperties MyProperty = MyAppLoader.SerialiseProperty();
                                    if (MyProperty != null)
                                    {
                                        this.ListApps.Add(new PowerApps(entry.Name, MyProperty.Name, MemStream, MyProperty.DocumentType));
                                    }
                                    else
                                    {
                                        this.ListApps.Add(new PowerApps(entry.Name, entry.Name, MemStream, ""));
                                    }
                                }
                            }
                            else if (entry.FullName.Contains("Workflows/"))
                            {
                                this.ListFlows.Add(new PowerAutomate(entry.Name, SolutionLoader.ReadEntryToTheEnd(entry)));
                            }
                            else if (entry.FullName.Contains("Formulas/"))
                            {
                                this.ListFormulas.Add(new EnvFormulas(entry.Name, SolutionLoader.ReadEntryToTheEnd(entry)));
                            }
                            else if (entry.FullName.Contains("environmentvariabledefinitions/"))
                            {
                                this.ListVariables.Add(new EnvVariable(entry.Name, SolutionLoader.ReadEntryToTheEnd(entry)));
                            }
                            else if (entry.FullName.Contains("WebResources/"))
                            {
                                this.ListRessources.Add(new FileWebRessource(entry.Name, SolutionLoader.ReadEntryToTheEnd(entry).Length));
                            }
                        }
                    }
                }
                else if (typeImport.ToLowerInvariant() == "apps" || typeImport.ToLowerInvariant() == "appurl")
                {
                    using (MemStream = new MemoryStream())
                    {
                        //MemStream = new MemoryStream();
                        StreamZip.CopyTo(MemStream);

                        try
                        {
                            StreamZip.Position = 0;
                            StreamZip.Seek(0, SeekOrigin.Begin);
                        }
                        catch (Exception ex)
                        {
                        }

                        MsappLoader MyAppLoaderOnly = new MsappLoader(MemStream);
                        MemStream = new MemoryStream();
                        StreamZip.CopyTo(MemStream);

                        MsappProperties MyPropertyOnly = MyAppLoaderOnly.SerialiseProperty();
                        if (MyPropertyOnly != null)
                        {
                            this.ListApps.Add(new PowerApps(PowerAppsFileName, MyPropertyOnly.Name, MemStream, "App"));
                        }
                        else
                        {
                            this.ListApps.Add(new PowerApps(PowerAppsFileName, PowerAppsFileName, MemStream, "App"));
                        }
                    }
                }

                PowerApps AppPage;
                List<PowerApps> ListToStore;
                List<PowerApps> TmpApps = this.ListApps;
                AppContainer AppStructure;
                if (MyExportXml != null)
                {
                    if (MyExportXml.AppModules != null)
                    {
                        foreach (AppModule MyAppContenair in MyExportXml.AppModules.AppModule)
                        {
                            ListToStore = new List<PowerApps>();
                            if (MyAppContenair.Appelements != null)
                            {
                                foreach (Appelement OneElmt in MyAppContenair.Appelements.Appelement)
                                {
                                    AppPage = this.ListApps.Find(x => x.NomPowerAppsFichier.Contains(OneElmt.Canvasappid.Name));
                                    //AppPage.NomPowerApps = OneElmt.Canvasappid.Name;
                                    if (AppPage != null)
                                    {
                                        ListToStore.Add(AppPage);
                                        TmpApps.Remove(AppPage);
                                    }
                                }
                            }

                            AppStructure = new AppContainer(MyAppContenair.LocalizedNames.LocalizedName.Description, ListToStore);
                            this.AppOrganisations.Add(AppStructure);
                        }
                    }
                }

                foreach (PowerApps RemainingApp in TmpApps)
                {
                    //RemainingApp.NomPowerApps=
                    AppStructure = new AppContainer(RemainingApp.NomPowerApps);
                    AppStructure.AddApp(RemainingApp);
                    this.AppOrganisations.Add(AppStructure);
                }

                if (tracingService != null) tracingService.Trace($"No of Apps : {this.ListApps.Count}");
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in SolutionLoader(). Message : {ex.Message}");
                throw;
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
    }
}