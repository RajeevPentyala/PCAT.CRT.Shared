using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using Net.Formulas.Tools.DataverseLib;

namespace Net.Formulas.Tools.Tools
{
    /// <summary>
    /// On Update of cat_rev_screens(i.e.,Rev_Screens) record
    /// </summary>
    public class CodeAutoFailProcessPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));


            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            tracingService.Trace("Begin AutoFailProcessPlugin : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());

            if (context.Depth != 4) return;

            Random MyRand = new Random();
            //System.Threading.Thread.Sleep(MyRand.Next(50, 500));

            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {

                OptionSetValue OptionReviewNotStarted = new OptionSetValue(695100000);
                OptionSetValue OptionReviewInProgress = new OptionSetValue(695100001);
                OptionSetValue OptionReviewCompleted = new OptionSetValue(695100002);

                Entity entity = (Entity)context.InputParameters["Target"];

                IOrganizationServiceFactory serviceFactory =
                    (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                DataverseOperator myOperator = new DataverseOperator(service);

                try
                {
                    DataAccessLogic.LogPlugginAction(myOperator, "AutoFailCode", context.Depth);

                    Guid screenGuid = new Guid(entity.Attributes["cat_rev_screensid"].ToString());

                    Entity UpdatedEntity = DataAccessLogic.GetEntityDatas(service, "cat_rev_screens", screenGuid);


                    Entity entityUpdatedReview = DataAccessLogic.GetEntityFromARelatedOne(service, UpdatedEntity, "cat_rel_screen_review", "cat_review");
                    Guid reviewGuid = new Guid(entityUpdatedReview.Attributes["cat_reviewid"].ToString());

                    try
                    {
                        Entity RelatedScreenOneOrZero = null;

                        if (UpdatedEntity != null && UpdatedEntity.Attributes.ContainsKey("cat_nb_publishorderindexscreen"))
                        {
                            int levelMyscreen = (int)UpdatedEntity.Attributes["cat_nb_publishorderindexscreen"];
                            FetchXmlFormatter xmlFetcher;

                            tracingService.Trace("Fetching Review Screens under Review");
                            xmlFetcher = new FetchXmlFormatter("cat_rev_screens");
                            xmlFetcher.AddFieldColumn("cat_rev_screensid");
                            xmlFetcher.AddFieldColumn("cat_txt_listfails");
                            xmlFetcher.AddFieldColumn("cat_rel_screen_review");
                            xmlFetcher.AddFieldColumn("cat_nb_publishorderindexscreen");
                            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                            xmlFetcher.OMyFilter.AddFilter("cat_rel_screen_review", "eq", reviewGuid.ToString());
                            var listReviewScreens = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
                            tracingService.Trace($"Fetched {listReviewScreens.Count} Review Screens");

                            switch (levelMyscreen)
                            {
                                case 1:
                                    //xmlFetcher = new FetchXmlFormatter("cat_rev_screens");
                                    //xmlFetcher.AddFieldColumn("cat_rev_screensid");
                                    //xmlFetcher.AddFieldColumn("cat_txt_listfails");
                                    //xmlFetcher.AddFieldColumn("cat_rel_screen_review");
                                    //xmlFetcher.AddFieldColumn("cat_nb_publishorderindexscreen");
                                    //xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                                    //xmlFetcher.OMyFilter.AddFilter("cat_rel_screen_review", "eq", reviewGuid.ToString());
                                    RelatedScreenOneOrZero = listReviewScreens.Find(x => (int)x.Attributes["cat_nb_publishorderindexscreen"] == 0);
                                    break;
                                case 0:
                                    //xmlFetcher = new FetchXmlFormatter("cat_rev_screens");
                                    //xmlFetcher.AddFieldColumn("cat_rev_screensid");
                                    //xmlFetcher.AddFieldColumn("cat_txt_listfails");
                                    //xmlFetcher.AddFieldColumn("cat_rel_screen_review");
                                    //xmlFetcher.AddFieldColumn("cat_nb_publishorderindexscreen");
                                    //xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                                    //xmlFetcher.OMyFilter.AddFilter("cat_rel_screen_review", "eq", reviewGuid.ToString());
                                    RelatedScreenOneOrZero = listReviewScreens.Find(x => (int)x.Attributes["cat_nb_publishorderindexscreen"] == 1);
                                    break;
                            }
                        }

                        DataAccessLogic.ProcessCodesAutoFailOneScreen(myOperator, reviewGuid, UpdatedEntity, tracingService, RelatedScreenOneOrZero);

                        DataAccessLogic.CalculateReviewScore(myOperator, entityUpdatedReview);
                    }
                    catch (FaultException<OrganizationServiceFault> ex)
                    {
                        tracingService.Trace(" Setting status to Error.... ");
                        //DataAccessLogic.UpdateReviewStatus(myOperator, reviewGuid, OptionReviewError, "cat_chc_statusimportappcheckerresults");

                        DataAccessLogic.LogPlugginAction(myOperator, "Code autofail status to Error....Catch1 : " + ex.Message, context.Depth);
                        throw new InvalidPluginExecutionException("An error occurred in FollowUpPlugin.", ex);
                    }
                }
                catch (Exception ex)
                {

                    DataAccessLogic.LogPlugginAction(myOperator, "Code autofail status to Error....Catch2 : " + ex.Message, context.Depth);
                    tracingService.Trace("Error reviewItem: {0}", ex.ToString());
                    throw;
                }
                finally
                {
                    tracingService.Trace("End AutoFailProcessPlugin : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());
                }
            }
        }
    }
}
