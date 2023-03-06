using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using CodeViewerExtractor;
using System.IO;
using Microsoft.PowerPlatform.Formulas.Tools;
using Microsoft.Xrm.Tooling.Connector;
using Newtonsoft.Json;

namespace Microsoft.PowerPlatform.PowerCAT.Tools
{
    public class CodeViewerPluggin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            
            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                
                Entity entity = (Entity)context.InputParameters["Target"];

                
                IOrganizationServiceFactory serviceFactory =
                    (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                try
                {
                    tracingService.Trace("FollowupPlugin: Creating the task activity.");

                    //TODO: replace code here.
                    //Entity followup = new Entity("cat_reviewitem");
                    //followup["cat_name"] = "Send e-mail to the new customer.";
                    //service.Create(followup);
                    DataverseOperator myOperator = new DataverseOperator("https://orgf13f21b3.crm.dynamics.com", "93c32c72-f056-42ae-8c31-450e0ba4cf71", "HQ4a8~5mVm~Q0rZ.EAOz549S-8xZ66k_.F", true, "");
                    Guid reviewGuid = new Guid(entity.Attributes["cat_reviewid"].ToString());//GetReviewID(myOperator, args[2]);


                    FileData MyfileData = myOperator.GetFileColumnContent("cat_review", "cat_msappfile", reviewGuid);
                    MemoryStream streamToOpen = new MemoryStream(MyfileData.File);

                    (CanvasDocument msApp, ErrorContainer errors) = CanvasDocument.LoadFromMsappStream(streamToOpen);

                    if (errors.HasErrors)
                    {
                        return;
                    }

                    Console.WriteLine(" Purge existing data.... ");
                    CleanExistingTables(myOperator, reviewGuid);

                    Console.WriteLine(" Processing Screens.... ");
                    ProcessScreens(msApp, myOperator, reviewGuid);

                    Console.WriteLine(" Processing App Checker Results.... ");
                    ProcessAppCheckerResults(msApp, myOperator, reviewGuid);

                    Console.WriteLine(" Processing App Settings .... ");
                    ProcessAppSettings(msApp, myOperator, reviewGuid, entity.Attributes["cat_name"].ToString());

                    Console.WriteLine(" Processing Review Items .... ");
                    ProcessReviewItemsStatus(myOperator, reviewGuid);

                    UpdateReviewStatus(myOperator, reviewGuid, 695100002);

                    myOperator.ReleaseConnection();



                }



                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in FollowUpPlugin.", ex);
                }

                catch (Exception ex)
                {
                    tracingService.Trace("FollowUpPlugin: {0}", ex.ToString());
                    throw;
                }
            }
        }

        private static void ProcessAppCheckerResults(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid)
        {
            AppCheckerResult appCheckerResults = (AppCheckerResult)JsonConvert.DeserializeObject<AppCheckerResult>(msApp._entropy.AppCheckerResult);

            Run LastRun = appCheckerResults.runs.Last<Run>();
            List<Entity> results;
            Guid MyResultGUID;
            Guid MyResultReviewGUID;
            Guid MyResultRecordGuid;
            Dictionary<string, CrmDataTypeWrapper> newDatas;
            FetchXmlFormatter xmlFetcher;
            string PhysicalLocationRegionLength = "", PhysicalLocationRegionSniplet = "", PhysicalLocationRegionOffest = "", LogicalLocationFullQualifiedName = "";
            string LocationPropertiesMember = "", LocationPropertiesModule = "", PhysicalLocationFullyQualifiedName = "", PhysicalLocationRelativeAdress = "";
            foreach (Result OneResult in LastRun.results)
            {


                xmlFetcher = new FetchXmlFormatter("cat_rev_appchecker_rulesreferences");
                xmlFetcher.MaxRows = 1;
                xmlFetcher.AddFieldColumn("cat_reviewitemid");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_lb_ruleid_ref", "eq", OneResult.ruleId);
                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());
                if (results.Count() > 0)
                {
                    MyResultGUID = new Guid(results.First().Attributes["cat_reviewitemid"].ToString());
                }
                else
                {
                    newDatas = new Dictionary<string, CrmDataTypeWrapper>();
                    newDatas.Add("cat_lb_ruleid_ref", new CrmDataTypeWrapper(OneResult.ruleId, CrmFieldType.String));

                    MyResultGUID = myOperator.QueryCreate("cat_rev_appchecker_rulesreferences", newDatas);

                }

                //cat_rev_appcheckerresult_review
                //cat_lb_ruleid_result eq '@{items('Runs-Results')?['ruleId']}' and _cat_relappchecker_resultreview_review_value eq '@{variables('Guid_review')}'

                xmlFetcher = new FetchXmlFormatter("cat_rev_appcheckerresult_review");
                xmlFetcher.MaxRows = 1;
                xmlFetcher.AddFieldColumn("cat_rev_appcheckerresult_reviewid");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_lb_ruleid_result", "eq", OneResult.ruleId);
                xmlFetcher.OMyFilter.AddFilter("cat_relappchecker_resultreview_review", "eq", reviewGuid.ToString());
                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());
                if (results.Count() > 0)
                {
                    MyResultReviewGUID = new Guid(results.First().Attributes["cat_rev_appcheckerresult_reviewid"].ToString());
                }
                else
                {
                    newDatas = new Dictionary<string, CrmDataTypeWrapper>();
                    newDatas.Add("cat_lb_ruleid_result", new CrmDataTypeWrapper(OneResult.ruleId, CrmFieldType.String));
                    newDatas.Add("cat_relappchecker_resultreview_review", new CrmDataTypeWrapper(reviewGuid, CrmFieldType.Lookup));

                    newDatas.Add("cat_rel_appchecker_resultreview_rules", new CrmDataTypeWrapper(MyResultGUID, CrmFieldType.Lookup));
                    //newDatas.Add("cat_rel_appchecker_resultreview_rulesreferenc", new CrmDataTypeWrapper(MyResultGUID, CrmFieldType.Lookup));
                    //
                    MyResultReviewGUID = myOperator.QueryCreate("cat_rev_appcheckerresult_review", newDatas);

                }

                foreach (Location OneLocation in OneResult.locations)
                {
                    if (OneLocation.physicalLocation.address == null)
                    {
                        PhysicalLocationRegionLength = "";
                        PhysicalLocationRegionSniplet = "";
                        PhysicalLocationRegionOffest = "";
                    }
                    else
                    {
                        PhysicalLocationRegionLength = OneLocation.physicalLocation.address.fullyQualifiedName.Length.ToString();
                        PhysicalLocationRegionSniplet = "";
                        PhysicalLocationRegionOffest = "";
                    }
                    LogicalLocationFullQualifiedName = OneLocation.logicalLocations[0].fullyQualifiedName;
                    LocationPropertiesMember = OneLocation.properties.member;
                    LocationPropertiesModule = OneLocation.properties.module;
                    PhysicalLocationFullyQualifiedName = OneLocation.physicalLocation.address.fullyQualifiedName;
                    PhysicalLocationRelativeAdress = OneLocation.physicalLocation.address.relativeAddress.ToString();
                }

                newDatas = new Dictionary<string, CrmDataTypeWrapper>();
                newDatas.Add("cat_lb_ruleid", new CrmDataTypeWrapper(OneResult.ruleId, CrmFieldType.String));

                newDatas.Add("cat_lb_physicallocation_region_charlength", new CrmDataTypeWrapper(PhysicalLocationRegionLength, CrmFieldType.String));
                newDatas.Add("cat_lb_physicallocation_region_snippet", new CrmDataTypeWrapper(PhysicalLocationRegionSniplet, CrmFieldType.String));
                newDatas.Add("cat_lb_physicallocation_region_charoffset", new CrmDataTypeWrapper(PhysicalLocationRegionOffest, CrmFieldType.String));

                newDatas.Add("cat_lb_logicallocation_fullyqualifiedname", new CrmDataTypeWrapper(LogicalLocationFullQualifiedName, CrmFieldType.String));

                newDatas.Add("cat_lb_messageid", new CrmDataTypeWrapper(OneResult.message.id, CrmFieldType.String));

                newDatas.Add("cat_lb_location_propertiesmember", new CrmDataTypeWrapper(LocationPropertiesMember, CrmFieldType.String));
                newDatas.Add("cat_lb_location_propertiesmodule", new CrmDataTypeWrapper(LocationPropertiesModule, CrmFieldType.String));

                newDatas.Add("cat_nb_ruleindex", new CrmDataTypeWrapper(OneResult.ruleIndex, CrmFieldType.CrmNumber));

                newDatas.Add("cat_lb_physicallocation_fullyqualifiedname", new CrmDataTypeWrapper(PhysicalLocationFullyQualifiedName, CrmFieldType.String));
                newDatas.Add("cat_lb_physicallocation_relativeaddress", new CrmDataTypeWrapper(PhysicalLocationRelativeAdress, CrmFieldType.String));


                newDatas.Add("cat_rel_appchecker_result_review", new CrmDataTypeWrapper(reviewGuid, CrmFieldType.Lookup));
                newDatas.Add("cat_rel_appcheckerresult_resultsrevie", new CrmDataTypeWrapper(MyResultReviewGUID, CrmFieldType.Lookup));
                //
                MyResultRecordGuid = myOperator.QueryCreate("cat_rev_appchecker_results", newDatas);

                if (OneResult.message.arguments != null)
                {
                    foreach (string OneArgument in OneResult.message.arguments)//supposed to be OneResult.message.aguments.count()>0
                    {

                        newDatas = new Dictionary<string, CrmDataTypeWrapper>();
                        newDatas.Add("cat_lb_argument", new CrmDataTypeWrapper(OneArgument, CrmFieldType.String));

                        newDatas.Add("cat_rel_appcheckerargument_review", new CrmDataTypeWrapper(reviewGuid, CrmFieldType.Lookup));
                        newDatas.Add("cat_rel_appcheckerarguments_results", new CrmDataTypeWrapper(MyResultRecordGuid, CrmFieldType.Lookup));
                        MyResultReviewGUID = myOperator.QueryCreate("cat_rev_appcheckermessagesarguments", newDatas);

                    }
                }


            }

            foreach (Rule OneRule in LastRun.tool.driver.rules)
            {
                //cat_lb_ruleid_ref
                xmlFetcher = new FetchXmlFormatter("cat_rev_appchecker_rulesreferences");
                xmlFetcher.MaxRows = 1;
                xmlFetcher.AddFieldColumn("cat_rev_appchecker_rulesreferencesid");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_lb_ruleid_ref", "eq", OneRule.id);
                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());

                newDatas = new Dictionary<string, CrmDataTypeWrapper>();
                newDatas.Add("cat_lb_ruleid_ref", new CrmDataTypeWrapper(OneRule.id, CrmFieldType.String));
                newDatas.Add("cat_lb_componenttype", new CrmDataTypeWrapper(OneRule.properties.componentType, CrmFieldType.String));
                newDatas.Add("cat_lb_level_ref", new CrmDataTypeWrapper(OneRule.properties.level, CrmFieldType.String));
                newDatas.Add("cat_lb_whyfix", new CrmDataTypeWrapper(OneRule.properties.whyFix, CrmFieldType.String));
                newDatas.Add("cat_lb_messageissue_ref", new CrmDataTypeWrapper("", CrmFieldType.String));//Missing!!!!
                newDatas.Add("cat_lb_primarycategory", new CrmDataTypeWrapper(OneRule.properties.primaryCategory, CrmFieldType.String));

                if (results.Count() > 0)
                {
                    MyResultGUID = new Guid(results.First().Attributes["cat_rev_appchecker_rulesreferencesid"].ToString());

                    myOperator.QueryUpdate("cat_rev_appchecker_rulesreferences", "cat_rev_appchecker_rulesreferencesid", MyResultGUID, newDatas);

                }
                else
                {

                    MyResultGUID = myOperator.QueryCreate("cat_rev_appchecker_rulesreferences", newDatas);

                }

                foreach (string HowtoFix in OneRule.properties.howToFix)
                {
                    if (HowtoFix != null)
                    {

                        xmlFetcher = new FetchXmlFormatter("cat_rev_appchecker_howtofix");
                        xmlFetcher.MaxRows = 1;
                        xmlFetcher.AddFieldColumn("cat_rev_appchecker_howtofixid");
                        xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                        xmlFetcher.OMyFilter.AddFilter("cat_lbhowtofix", "eq", HowtoFix);
                        xmlFetcher.OMyFilter.AddFilter("cat_rel_appcheckerhowtofix_rulesrefer", "eq", MyResultGUID.ToString());

                        results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());

                        if (results.Count == 0 || results == null)
                        {
                            newDatas = new Dictionary<string, CrmDataTypeWrapper>();
                            newDatas.Add("cat_lbhowtofix", new CrmDataTypeWrapper(HowtoFix, CrmFieldType.String));
                            newDatas.Add("cat_rel_appcheckerhowtofix_rulesreferences", new CrmDataTypeWrapper(MyResultGUID.ToString(), CrmFieldType.String));
                            MyResultGUID = myOperator.QueryCreate("cat_rev_appchecker_howtofix", newDatas);

                        }

                    }
                }


            }
            //

        }

        private static void ProcessAppSettings(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid, string ReviewName)
        {
            Dictionary<string, CrmDataTypeWrapper> newDatas;
            foreach (string OneProperty in msApp._properties.AppPreviewFlagsKey)
            {
                newDatas = new Dictionary<string, CrmDataTypeWrapper>();
                newDatas.Add("cat_lb_parametername", new CrmDataTypeWrapper(OneProperty, CrmFieldType.String));
                newDatas.Add("cat_lb_parametervalue", new CrmDataTypeWrapper("true", CrmFieldType.String));
                newDatas.Add("cat_lb_reviewname", new CrmDataTypeWrapper(ReviewName, CrmFieldType.String));

                newDatas.Add("cat_rel_appsettings_review", new CrmDataTypeWrapper(reviewGuid, CrmFieldType.Lookup));

                myOperator.QueryCreate("cat_rev_appsettings", newDatas);
                //Microsoft.AppMagic.Authoring.Persistence.DocumentPropertiesJson
            }

            newDatas = new Dictionary<string, CrmDataTypeWrapper>();
            newDatas.Add("cat_lb_parametername", new CrmDataTypeWrapper("DocumentLayoutScaleToFit", CrmFieldType.String));
            newDatas.Add("cat_lb_parametervalue", new CrmDataTypeWrapper(msApp._properties.DocumentLayoutScaleToFit.ToString(), CrmFieldType.String));
            newDatas.Add("cat_lb_reviewname", new CrmDataTypeWrapper(ReviewName, CrmFieldType.String));
            newDatas.Add("cat_rel_appsettings_review", new CrmDataTypeWrapper(reviewGuid, CrmFieldType.Lookup));
            myOperator.QueryCreate("cat_rev_appsettings", newDatas);

            newDatas = new Dictionary<string, CrmDataTypeWrapper>();
            newDatas.Add("cat_lb_parametername", new CrmDataTypeWrapper("DefaultConnectedDataSourceMaxGetRowsCount", CrmFieldType.String));
            newDatas.Add("cat_lb_parametervalue", new CrmDataTypeWrapper(msApp._properties.DefaultConnectedDataSourceMaxGetRowsCount.ToString(), CrmFieldType.String));
            newDatas.Add("cat_lb_reviewname", new CrmDataTypeWrapper(ReviewName, CrmFieldType.String));
            newDatas.Add("cat_rel_appsettings_review", new CrmDataTypeWrapper(reviewGuid, CrmFieldType.Lookup));
            myOperator.QueryCreate("cat_rev_appsettings", newDatas);

            newDatas = new Dictionary<string, CrmDataTypeWrapper>();
            newDatas.Add("cat_lb_parametername", new CrmDataTypeWrapper("DocumentLayoutMaintainAspectRatio", CrmFieldType.String));
            newDatas.Add("cat_lb_parametervalue", new CrmDataTypeWrapper(msApp._properties.DocumentLayoutMaintainAspectRatio.ToString(), CrmFieldType.String));
            newDatas.Add("cat_lb_reviewname", new CrmDataTypeWrapper(ReviewName, CrmFieldType.String));
            newDatas.Add("cat_rel_appsettings_review", new CrmDataTypeWrapper(reviewGuid, CrmFieldType.Lookup));
            myOperator.QueryCreate("cat_rev_appsettings", newDatas);

        }
        
        
        private static Guid GetReviewID(DataverseOperator myOperator, string reviewName)
        {
            List<Entity> results;
            FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_review");
            xmlFetcher.MaxRows = 1;
            xmlFetcher.AddFieldColumn("cat_reviewid");
            xmlFetcher.AddFieldColumn("cat_name");
            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
            xmlFetcher.OMyFilter.AddFilter("cat_name", "eq", reviewName);
            results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());
            Guid reviewGuid = new Guid(results.First().Attributes["cat_reviewid"].ToString());
            return reviewGuid;
        }

        private static void ProcessReviewItemsStatus(DataverseOperator myOperator, Guid reviewGuid)
        {
            List<Entity> resultsAppChecker;
            bool IsRuleRefFounded = false;
            FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_pattern");
            xmlFetcher.AddFieldColumn("cat_patternid");
            xmlFetcher.AddFieldColumn("cat_name");
            List<Entity> results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());

            xmlFetcher = new FetchXmlFormatter("cat_rev_rulesreferences_patterns");
            xmlFetcher.AddFieldColumn("cat_patternid");
            xmlFetcher.AddFieldColumn("cat_rev_appchecker_rulesreferencesid");
            List<Entity> ListRulesReferencePatterns = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());
            string cat_rev_appchecker_rulesreferencesid = "";

            Dictionary<string, CrmDataTypeWrapper> newParams;
            foreach (Entity oneRes in results)
            {
                xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
                xmlFetcher.AddFieldColumn("cat_reviewitemid");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_pattern", "eq", oneRes.Attributes["cat_patternid"].ToString());
                xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", reviewGuid.ToString());
                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());
                if (results.Count() == 0)
                {

                    List<Entity> ConflictRefPatterns = ListRulesReferencePatterns.Where(x => x.Attributes["cat_patternid"].ToString() == oneRes.Attributes["cat_patternid"].ToString()).ToList();

                    if (ConflictRefPatterns.Count() > 0)
                    {
                        IsRuleRefFounded = false;
                        //cat_rev_appcheckerresult_review
                        foreach (Entity OneConflict in ConflictRefPatterns)
                        {
                            xmlFetcher = new FetchXmlFormatter("cat_rev_appcheckerresult_review");
                            xmlFetcher.AddFieldColumn("cat_rev_appcheckerresult_reviewid");
                            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                            xmlFetcher.OMyFilter.AddFilter("cat_relappchecker_resultreview_review", "eq", reviewGuid.ToString());
                            xmlFetcher.OMyFilter.AddFilter("cat_rel_appchecker_resultreview_rules", "eq", OneConflict.Attributes["cat_rev_appchecker_rulesreferencesid"].ToString());
                            resultsAppChecker = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());

                            cat_rev_appchecker_rulesreferencesid = "";
                            IsRuleRefFounded = (resultsAppChecker.Count() > 0);
                            if (IsRuleRefFounded)
                            {

                                cat_rev_appchecker_rulesreferencesid = OneConflict.Attributes["cat_rev_appchecker_rulesreferencesid"].ToString();
                                Dictionary<string, CrmDataTypeWrapper> newDatas = new Dictionary<string, CrmDataTypeWrapper>();
                                newDatas.Add("cat_review", new CrmDataTypeWrapper(reviewGuid, CrmFieldType.Lookup));
                                newDatas.Add("cat_pattern", new CrmDataTypeWrapper(new Guid(oneRes.Attributes["cat_patternid"].ToString()), CrmFieldType.Lookup));
                                if (IsRuleRefFounded)
                                {
                                    newDatas.Add("cat_reviewitemstatus", new CrmDataTypeWrapper(695100002, CrmFieldType.Picklist));
                                }
                                else
                                {
                                    newDatas.Add("cat_reviewitemstatus", new CrmDataTypeWrapper(695100001, CrmFieldType.Picklist));
                                }


                                //Test must define this value
                                myOperator.QueryCreate("cat_reviewitem", newDatas);



                                foreach (Entity OneAppRes in resultsAppChecker)
                                {
                                    newParams = new Dictionary<string, CrmDataTypeWrapper>();
                                    newParams.Add("cat_reviewItem_cat_reviewitem_cat_rev_app", new CrmDataTypeWrapper(new Guid(results.First().Attributes["cat_reviewitemid"].ToString()), CrmFieldType.Lookup));
                                    myOperator.QueryUpdate("cat_rev_appcheckerresult_review", "cat_rev_appcheckerresult_reviewid", new Guid(OneAppRes.Attributes["cat_rev_appcheckerresult_reviewid"].ToString()), newParams);
                                }

                                break;
                            }



                        }

                        //Autofail test to do here


                    }


                }

            }
        }

        private static void ProcessScreens(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid)
        {
            int indexNum;
            Dictionary<string, CrmDataTypeWrapper> newDatas = new Dictionary<string, CrmDataTypeWrapper>();
            Guid ScreenGuid;
            foreach (KeyValuePair<string, Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode> OneScreen in msApp._screens)
            {

                if (msApp._entropy.PublishOrderIndexOffsets.Keys.Contains(OneScreen.Key))
                {
                    indexNum = Convert.ToInt32(msApp._entropy.PublishOrderIndexOffsets[OneScreen.Key]);
                }
                else
                {
                    indexNum = 0;
                }

                Console.WriteLine("==> Processing screen: {0}", OneScreen.Key);
                newDatas.Add("cat_lb_namescreen", new CrmDataTypeWrapper(OneScreen.Key, CrmFieldType.String));
                newDatas.Add("cat_lb_layoutnamescreen", new CrmDataTypeWrapper("", CrmFieldType.String));
                newDatas.Add("cat_lb_stylenamescreen", new CrmDataTypeWrapper(OneScreen.Value.Name.Kind.TypeName, CrmFieldType.String));
                newDatas.Add("cat_nb_publishorderindexscreen", new CrmDataTypeWrapper(1, CrmFieldType.CrmNumber));
                newDatas.Add("cat_rel_screen_review", new CrmDataTypeWrapper(reviewGuid, CrmFieldType.Lookup));
                ScreenGuid = myOperator.QueryCreate("cat_rev_screens", newDatas);
                newDatas = new Dictionary<string, CrmDataTypeWrapper>();

                if (OneScreen.Value.Properties.ToList().Count() > 0)
                {
                    ImportProperties(OneScreen.Value.Properties.ToList(), OneScreen.Key, "", reviewGuid, ScreenGuid, Guid.Empty, myOperator);
                }

                if (OneScreen.Value.Children.ToList().Count() > 0)
                {
                    ImportSubControls(OneScreen.Key, OneScreen.Value.Children.ToList(), myOperator, reviewGuid, ScreenGuid, Guid.Empty);
                }

            }


        }

        private static void CleanExistingTables(DataverseOperator myOperator, Guid reviewGuid)
        {
            //Clean Screen Loading
            PurgeTable("cat_rev_screens", reviewGuid, "cat_rev_screensid", "cat_rel_screen_review", myOperator);
            PurgeTable("cat_rev_controls", reviewGuid, "cat_rev_controlsid", "cat_rel_control_review", myOperator);
            PurgeTable("cat_rev_propertiescode", reviewGuid, "cat_rev_propertiescodeid", "cat_rel_properties_review", myOperator);

            //Cleaning appResults
            PurgeTable("cat_rev_appcheckermessagesarguments", reviewGuid, "cat_rev_appcheckermessagesargumentsid", "cat_rel_appcheckerargument_review", myOperator);
            PurgeTable("cat_rev_appchecker_results", reviewGuid, "cat_rev_appchecker_resultsid", "cat_Rev_AppChecker_Results_Review", myOperator);
            PurgeTable("cat_rev_appcheckerresult_review", reviewGuid, "cat_rev_appcheckerresult_reviewid", "cat_relappchecker_resultreview_review", myOperator);

            //Cleaning AppSettings
            PurgeTable("cat_rev_appSettings", reviewGuid, "cat_rev_appsettingsid", "cat_rel_appsettings_review", myOperator);

        }

        private static void ImportSubControls(string StrNameScreen, List<Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode> ListControls, DataverseOperator MyOperator, Guid GReview, Guid GScreen, Guid GControl)
        {
            Guid GuidNvControl;
            Dictionary<string, CrmDataTypeWrapper> newDatas;
            foreach (Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode SubControl in ListControls)
            {
                newDatas = new Dictionary<string, CrmDataTypeWrapper>();
                newDatas.Add("cat_lb_typecontrol", new CrmDataTypeWrapper(SubControl.Name.Kind.ToString(), CrmFieldType.String));
                newDatas.Add("cat_lb_namecontrol", new CrmDataTypeWrapper(SubControl.Name.Identifier, CrmFieldType.String));
                newDatas.Add("cat_nb_publishorderindexcontrol", new CrmDataTypeWrapper(1, CrmFieldType.CrmNumber));
                newDatas.Add("cat_rel_control_review", new CrmDataTypeWrapper(GReview, CrmFieldType.Lookup));
                newDatas.Add("cat_rel_controls_screens", new CrmDataTypeWrapper(GScreen, CrmFieldType.Lookup));
                if (GControl != Guid.Empty)
                {
                    newDatas.Add("cat_rel_controls_parent", new CrmDataTypeWrapper(GControl, CrmFieldType.Lookup));
                }
                GuidNvControl = MyOperator.QueryCreate("cat_rev_propertiescode", newDatas);

                if (SubControl.Properties.Count() > 0)
                {
                    ImportProperties(SubControl.Properties.ToList(), StrNameScreen, SubControl.Name.Identifier, GReview, GScreen, GuidNvControl, MyOperator);
                }
                if (SubControl.Children.Count() > 0)
                {
                    ImportSubControls(StrNameScreen, SubControl.Children.ToList(), MyOperator, GReview, GScreen, GuidNvControl);
                }
            }

        }

        private static void PurgeTable(string StrTableName, Guid GuidReview, string StrColIdName, string StrColRelReviewName, DataverseOperator MyOperator)
        {
            //Faire une fonction de purge
            FetchXmlFormatter MyFetcher = MyFetcher = new FetchXmlFormatter(StrTableName);
            MyFetcher.AddFieldColumn(StrColRelReviewName);
            MyFetcher.OMyFilter.StrLogicalOperator = "and";
            MyFetcher.OMyFilter.AddFilter(StrColRelReviewName, "eq", GuidReview.ToString());
            List<Entity> results = results = MyOperator.QuerySelect(MyFetcher.GenerateFetchXmltrong());

            foreach (Entity oneRes in results)
            {
                MyOperator.QueryDelete(StrTableName, new Guid(oneRes.Attributes[StrColIdName].ToString()));
            }
        }

        private static void ImportProperties(List<Microsoft.PowerPlatform.Formulas.Tools.IR.PropertyNode> ListProperties, string StrNameScreen, string StrNameControl, Guid GReview, Guid GScreen, Guid GControl, DataverseOperator MyOperator)//(string StrInvariantScript, string StrNameScreen, string StrNameControl, string StrNameProperty, string StrTypeProperty, Guid GReview, Guid GScreen, Guid GControl, DataverseOperator MyOperator)
        {
            string StrCleanedScript = "";
            int NbLengthScript;
            Dictionary<string, CrmDataTypeWrapper> newDatas;

            foreach (Microsoft.PowerPlatform.Formulas.Tools.IR.PropertyNode OneProp in ListProperties)
            {
                newDatas = new Dictionary<string, CrmDataTypeWrapper>();

                StrCleanedScript = OneProp.Expression.Expression.ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                NbLengthScript = OneProp.Expression.Expression.Length;
                if (NbLengthScript > 40)
                {
                    newDatas.Add("cat_nb_codesize", new CrmDataTypeWrapper(NbLengthScript, CrmFieldType.CrmNumber));
                    newDatas.Add("cat_lb_invariantscript_property_cleaned", new CrmDataTypeWrapper(StrCleanedScript, CrmFieldType.String));
                    newDatas.Add("cat_lb_invariantscript_property", new CrmDataTypeWrapper(OneProp.Expression.Expression.ToString(), CrmFieldType.String));
                    newDatas.Add("cat_lb_nameproperty", new CrmDataTypeWrapper(OneProp.Identifier.ToString(), CrmFieldType.String));
                    newDatas.Add("cat_lb_namescreen_property", new CrmDataTypeWrapper(StrNameScreen, CrmFieldType.String));
                    newDatas.Add("cat_lb_namecontrol_property", new CrmDataTypeWrapper(StrNameControl, CrmFieldType.String));
                    newDatas.Add("cat_lb_ruleprovidertype_property", new CrmDataTypeWrapper("", CrmFieldType.String));

                    newDatas.Add("cat_rel_properties_review", new CrmDataTypeWrapper(GReview, CrmFieldType.Lookup));
                    newDatas.Add("cat_rel_properties_screens", new CrmDataTypeWrapper(GScreen, CrmFieldType.Lookup));
                    if (GControl != Guid.Empty)
                    {
                        newDatas.Add("cat_rel_properties_controls", new CrmDataTypeWrapper(GControl, CrmFieldType.Lookup));
                    }
                    MyOperator.QueryCreate("cat_rev_propertiescode", newDatas);
                }

            }


        }

        private static void Usage()
        {
            Console.WriteLine(
                @"Usage

                -unpack PathToApp.msapp PathToNewSourceFolder
                -unpack PathToApp.msapp  // infers source folder
                -pack  NewPathToApp.msapp PathToSourceFolder
                -make PathToCreateApp.msapp PathToPkgFolder PathToPaFile

                ");
        }

        private static bool UpdateReviewStatus(DataverseOperator myOperator, Guid reviewGuid, int CodeStatus)
        {
            try
            {
                Dictionary<string, CrmDataTypeWrapper> newDatas = new Dictionary<string, CrmDataTypeWrapper>();

                newDatas.Add("cat_chc_statutimportglobal", new CrmDataTypeWrapper(CodeStatus, CrmFieldType.Picklist));

                //Test must define this value
                return myOperator.QueryUpdate("cat_review", "cat_reviewid", reviewGuid, newDatas);
            }
            catch (Exception ex)
            {
                return false;
            }

        }


    }


}
