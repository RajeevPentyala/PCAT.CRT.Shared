using Microsoft.PowerPlatform.Formulas.Tools;
using System;
using System.IO;
using Microsoft.Xrm.Tooling.Connector;
using DataverseLib;
using System.Configuration;
using Net.Formulas.Tools.DataverseLib;
using Microsoft.Xrm.Sdk;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Query;
using Net.Formulas.Tools.Solution;
using System.Transactions;
using Microsoft.Xrm.Client.Services;

namespace CodeViewerExtractor
{
    class Program
    {


        static CrmServiceClient ConnectToEnvironment(string[] args)
        {

            string envUrl = ConfigurationManager.AppSettings["EnvUrl"];
            string clientId = ConfigurationManager.AppSettings["ClientId"];
            string Secret = ConfigurationManager.AppSettings["ClientSecret"];

            var service = new CrmServiceClient(new Uri(envUrl), clientId, Secret, true, String.Empty);

            return service;
        }

        static void Main(string[] args)
        {

            var mode = args.Length > 0 ? args[0]?.ToLower() : null;
            OptionSetValue OptionReviewInProgress = new OptionSetValue(695100001);//695100001);
            OptionSetValue OptionReviewDone = new OptionSetValue(695100002);// 695100002);
            OptionSetValue OptionReviewNotStarted = new OptionSetValue(695100000);// 695100002);
            OptionSetValue OptionReviewError = new OptionSetValue(341200000);// 695100002);
            

            
            //new CrmServiceClient(new Uri(envUrl), clientId, Secret, true, String.Empty);


            //
            //myOperator = new DataverseOperator(service);

            var type = args.Length >= 2 ? args[2]?.ToLower() : null;


            if (type == "app")
            {
                var service = Program.ConnectToEnvironment(args);
                DataverseOperator myOperator;
                myOperator = new DataverseOperator(service);
                //Checks if there is is a rules update to do and does it
                DataAccessLogic.ProcessInitialLoading(myOperator);


                Console.WriteLine("************ Processing MSAPP file *********************");
                Guid reviewGuid = DataAccessLogic.GetReviewID(myOperator, args[1]);
                DataAccessLogic.GetReviewIDAll(myOperator);

                Entity UpdatedEntity = DataAccessLogic.GetEntityDatas(service, "cat_review", reviewGuid);


                Console.WriteLine(" Update status to Not started.... ");
                DataAccessLogic.UpdateReviewStatus(myOperator, reviewGuid, OptionReviewNotStarted, "cat_chc_statutimportglobal");

                try
                {
                    if (mode == "-unpack")
                    {
                        if (args.Length < 2)
                        {
                            DataAccessLogic.Usage();
                            return;
                        }

                        MemoryStream streamToOpen;

                        FileData MyfileData = myOperator.GetFileColumnContent("cat_review", "cat_msappfile", reviewGuid);

                        streamToOpen = new MemoryStream(MyfileData.File);

                        (CanvasDocument msApp, ErrorContainer errors) = CanvasDocument.LoadFromMsappStream(streamToOpen);

                        errors.Write(Console.Error);

                        if (errors.HasErrors)
                        {
                            return;
                        }
                        DataAccessLogic.ProcessVariables(msApp, myOperator, reviewGuid);

                        Console.WriteLine(" Update status to In progress.... ");
                        DataAccessLogic.UpdateReviewStatus(myOperator, reviewGuid, OptionReviewInProgress, "cat_chc_statutimportglobal");
                        Console.WriteLine(" Processing Score calculation.... ");
                        DataAccessLogic.CalculateReviewScore(myOperator, UpdatedEntity);

                        Console.WriteLine(" Processing Review Items .... ");
                        DataAccessLogic.ProcessReviewItemsImport(myOperator, reviewGuid);

                        Console.WriteLine(" Processing App Checker Results.... ");
                        DataAccessLogic.ProcessAppCheckerResults(msApp, myOperator, reviewGuid);


                        Console.WriteLine(" Processing App Settings .... ");
                        DataAccessLogic.ProcessAppSettings(msApp, myOperator, reviewGuid);
                        Console.WriteLine(" -> Settings .... ");
                        DataAccessLogic.ProcessSettingsAutoFail(service, myOperator, reviewGuid, DataAccessLogic.GetListSettingMandatory());


                        Console.WriteLine(" Purge existing data.... ");
                        DataAccessLogic.CleanExistingTables(myOperator, reviewGuid);

                        Console.WriteLine(" Processing Review Items .... ");
                        DataAccessLogic.ProcessReviewItemsImport(myOperator, reviewGuid);

                        Console.WriteLine(" Processing App Checker Results.... ");
                        DataAccessLogic.ProcessAppCheckerResults(msApp, myOperator, reviewGuid);

                        Console.WriteLine(" Processing App Settings .... ");
                        DataAccessLogic.ProcessAppSettings(msApp, myOperator, reviewGuid);

                        Console.WriteLine(" Processing DataFiles.... ");
                        DataAccessLogic.ProcessDataFiles(msApp, myOperator, reviewGuid);

                        Console.WriteLine(" Processing MediaFiles.... ");
                        DataAccessLogic.ProcessMediaFiles(msApp, myOperator, reviewGuid);

                        Console.WriteLine(" Processing Screens.... ");
                        DataAccessLogic.ProcessScreenCreation(msApp, myOperator, reviewGuid);
                        DataAccessLogic.ProcessScreens(msApp, myOperator, reviewGuid);

                        Console.WriteLine(" Processing Autofails.... ");
                        Console.WriteLine(" -> ReviewItems .... ");
                        DataAccessLogic.ProcessReviewItemsAutoFail(myOperator, reviewGuid);

                        Console.WriteLine(" -> Settings .... ");
                        DataAccessLogic.ProcessSettingsAutoFail(service, myOperator, reviewGuid, DataAccessLogic.GetListSettingMandatory());

                        Console.WriteLine(" -> FileSize/Assets .... ");
                        DataAccessLogic.ProcessFileSizeAssetsAutoFail(service, myOperator, reviewGuid, 300);

                        Console.WriteLine(" -> Codes .... ");
                        DataAccessLogic.ProcessCodesAutoFail(myOperator, reviewGuid);

                        Console.WriteLine(" Processing Score calculation.... ");
                        DataAccessLogic.CalculateReviewScore(myOperator, UpdatedEntity);

                        Console.WriteLine(" Update status to Done.... ");
                        DataAccessLogic.UpdateReviewStatus(myOperator, reviewGuid, OptionReviewDone, "cat_chc_statutimportglobal");

                    }
                    else
                    {
                        DataAccessLogic.Usage();
                    }
                }
                catch (Exception ex)
                {
                    DataAccessLogic.UpdateReviewStatus(myOperator, reviewGuid, OptionReviewError, "cat_chc_statutimportglobal");

                }
            }
            else if(type == "solution")
            {
                var service = Program.ConnectToEnvironment(args);
                DataverseOperator myOperator = new DataverseOperator(service);


                /*
                Entity UpdatedEntity = DataAccessLogic.GetEntityFromARelatedOne(service, TheEntity, "cat_rev_solution_review_request", "cat_rev_solutionreview");
                DataAccessLogic.LogPlugginAction(myOperator, "SolutionCreation", 1);

                if (UpdatedEntity.Attributes["cat_file_solutionzip"] == null && UpdatedEntity.Attributes["cat_file_msapp"] == null)
                {
                    return;
                }

                Guid reviewGuid = new Guid(UpdatedEntity.Attributes["cat_rev_solutionreviewid"].ToString());
                */

                
                Guid RequestGuid = DataAccessLogic.GetReviewID(myOperator, args[1], "cat_rev_solutionrequest", "cat_lbsolutionname", "cat_rev_solutionrequestid", "cat_lbsolutionname;cat_rev_solutionrequestid;cat_rev_solution_review_request");
                Entity TheEntity = DataAccessLogic.GetEntityValue(myOperator, RequestGuid, "cat_rev_solutionrequest", "cat_rev_solutionrequestid", "cat_lbsolutionname;cat_rev_solutionrequestid;cat_rev_solution_review_request");//(Entity)context.InputParameters["Target"];

                //Guid reviewGuid = DataAccessLogic.GetReviewID(myOperator, args[1], "cat_rev_solutionreview", "cat_lbsolutionreviewname", "cat_rev_solutionreviewid", "cat_lbsolutionreviewname;cat_rev_solutionreviewid;cat_file_msapp;cat_file_solutionzip");
                //Entity UpdatedEntity = DataAccessLogic.GetEntityValue(myOperator, reviewGuid, "cat_rev_solutionreview", "cat_rev_solutionreviewid", "cat_lbsolutionreviewname;cat_rev_solutionreviewid;cat_file_msapp;cat_file_solutionzip");


                Entity UpdatedEntity = DataAccessLogic.GetEntityFromARelatedOne(service, TheEntity, "cat_rev_solution_review_request", "cat_rev_solutionreview");
                    

                   

                Guid reviewGuid = new Guid(UpdatedEntity.Attributes["cat_rev_solutionreviewid"].ToString());
                
                //Entity AppToScore = DataAccessLogic.GetEntityFromARelatedOne(myOperator.getService(), UpdatedEntity, "cat_rev_reviews_apps", "cat_rev_apps") ;
                //Entity SolutionToScore = DataAccessLogic.GetEntityFromARelatedOne(myOperator.getService(), AppToScore, "cat_rev_apps_solutionreview", "cat_rev_solutionreview");

                /*
                FetchXmlFormatter xmlFetcher;
                xmlFetcher = new FetchXmlFormatter("cat_review");
                xmlFetcher.AddFieldColumn("cat_review_solutionreviews"); 
                xmlFetcher.AddFieldColumn("cat_name"); 
                xmlFetcher.AddFieldColumn("cat_rev_reviews_apps");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_review_solutionreviews", "eq", reviewGuid.ToString());
                List<Entity> ListReviewsApp = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());
                
                foreach (Entity OneReview in ListReviewsApp)
                {
                    DataAccessLogic.PropageScoreUntilSolution(myOperator, OneReview);
                    DataAccessLogic.PropagateStatusUntilSolution(myOperator, OneReview);
                }*/

                string typeImport;
                //CanvasDocument msApp = myOperator.getCanvasDoc(myOperator, reviewGuid, null, "cat_rev_solutionreview", "cat_file_msapp");

                //if (msApp == null) return;

                //DataAccessLogic.ProcessVariables(msApp, myOperator, reviewGuid);

                /*
                CanvasDocument msApp = myOperator.getCanvasDoc(myOperator, reviewGuid,null, "cat_rev_solutionreview", "cat_file_msapp");

                if (msApp == null) return;

                DataAccessLogic.ProcessVariables(msApp, myOperator, reviewGuid);

                Guid UpEnt = new Guid("eaafdc71-ab99-ec11-b400-002248225d81");
                Entity UpdatedReview = DataAccessLogic.GetEntityValue(myOperator, UpEnt,"cat_review","cat_reviewid", "cat_name;cat_nb_rankimportreviewitems;cat_chc_statutimportglobal;cat_review_solutionreviews;cat_rev_reviews_apps");

                DataAccessLogic.PropagateStatusUntilSolution(myOperator, UpdatedReview);
                DataAccessLogic.PropageScoreUntilSolution(myOperator, UpdatedReview);
                */



                try
                {

                    MemoryStream MyStream;
                    if (UpdatedEntity.Attributes.ContainsKey("cat_file_solutionzip"))
                    {
                        typeImport = "solution";
                        MyStream = myOperator.getSolutionZip(myOperator, reviewGuid, "cat_rev_solutionreview", "cat_file_solutionzip");
                    }
                    else if (UpdatedEntity.Attributes.ContainsKey("cat_file_msapp"))
                    {
                        typeImport = "Apps";
                        MyStream = myOperator.getSolutionZip(myOperator, reviewGuid, "cat_rev_solutionreview", "cat_file_msapp");
                    }
                    else
                    {
                        typeImport = "";
                        MyStream = null;
                    }

                    if (MyStream == null) return;

                    Console.WriteLine(" Processing Solution Import.... ");
                    SolutionLoader UploadedSolution = new SolutionLoader(MyStream, typeImport);

                    DataAccessLogic.LoadSolutionElements(myOperator, reviewGuid, UploadedSolution);



                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Solution Import status to Error.... ");

                    throw new InvalidPluginExecutionException("An error occurred in Solution Import.", ex);
                }

            }

            

        }

        private static void GenerateRulesAndPatternsFile(CrmServiceClient service)
        {



            // GENERATE XML FILE FOR RULES AND PATTERNS
            var pattenRulesQueries = new QueryExpression
            {
                EntityName = "cat_rev_rulesreferences_patterns",
                ColumnSet = new ColumnSet("cat_patternid", "cat_rev_appchecker_rulesreferencesid")
            };

            DataCollection<Entity> patternsRuleReferences = service.RetrieveMultiple(
                pattenRulesQueries).Entities;


            var rulereference = new QueryExpression
            {
                EntityName = "cat_rev_appchecker_rulesreferences",
                ColumnSet = new ColumnSet(true)
            };

            DataCollection<Entity> rules = service.RetrieveMultiple(rulereference).Entities;

            var patternsQuery = new QueryExpression
            {
                EntityName = "cat_pattern",
                ColumnSet = new ColumnSet("cat_patternid", "cat_category", "cat_title", "cat_name", "cat_description", "cat_severity", "cat_value", "cat_patterntype")
            };

            DataCollection<Entity> patterns = service.RetrieveMultiple(patternsQuery).Entities;


            Model model = new Model() { ModifiedDate = DateTime.Now , Version = 4 };

            model.Patterns = patterns.Select(x => new Pattern()
            {
                Name = x.Attributes["cat_name"].ToString(),
                Title = x.Attributes["cat_title"].ToString(),
                Description = x.Attributes["cat_description"].ToString(),
                Category = ((Microsoft.Xrm.Sdk.OptionSetValue)x.Attributes["cat_category"]).Value,
                PatternId = new Guid(x.Attributes["cat_patternid"].ToString()),
                ModifiedDate = DateTime.Now,
                Value = int.Parse(x.Attributes["cat_value"].ToString()),
                Severity = ((Microsoft.Xrm.Sdk.OptionSetValue)x.Attributes["cat_severity"]).Value,
                PatternType = ((Microsoft.Xrm.Sdk.OptionSetValue)x.Attributes["cat_patterntype"]).Value

            }).ToList();


            model.Rules = rules.Select(r => new Rule()
            {
                Name = r.Attributes["cat_lb_ruleid_ref"].ToString(),
                WhyFix = r.Attributes.Keys.Any(s => s == "cat_lb_whyfix") ? r.Attributes["cat_lb_whyfix"].ToString() : string.Empty,
                Level = r.Attributes["cat_lb_level_ref"].ToString(),
                ComponentType = r.Attributes["cat_lb_componenttype"].ToString(),
                PrimaryCategory = r.Attributes["cat_lb_primarycategory"].ToString(),

            }).ToList();

            foreach (var pattern in model.Patterns)
            {
                var rulesforPatern = new List<Rule>();

                var rulePatternsIds = patternsRuleReferences.Where(rp => rp.Attributes["cat_patternid"].ToString() == pattern.PatternId.ToString()).ToList()
                                                                    .Select(s => s.Attributes["cat_rev_appchecker_rulesreferencesid"].ToString()).ToList();

                var ruleReferences = rules.Where(r => rulePatternsIds.Contains(r.Attributes["cat_rev_appchecker_rulesreferencesid"].ToString())).ToList();

                pattern.Rules = ruleReferences.Select(s => new Rule()
                {
                    Name = s.Attributes["cat_lb_ruleid_ref"].ToString()
                }).ToList();

            }

            using (StreamWriter file = File.CreateText(@"C:\Users\mehdis\Documents\patternsrule.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Model));
                serializer.Serialize(file, model);
             }
        }
    }
}
