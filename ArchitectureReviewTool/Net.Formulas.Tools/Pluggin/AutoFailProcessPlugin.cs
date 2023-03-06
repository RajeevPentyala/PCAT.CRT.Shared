using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using Net.Formulas.Tools.DataverseLib;

namespace Net.Formulas.Tools.Tools
{
    /// <summary>
    /// On Update of cat_reviewrequest(i.e.,ReviewRequest) record
    /// </summary>
    public class AutoFailProcessPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));


            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            tracingService.Trace("Begin AutoFailProcessPlugin : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());

            if (context.Depth != 3 && context.Depth != 4)
            {
                tracingService.Trace($"Exiting due to depth check; Depth - {context.Depth}");
                return;
            }

            Random MyRand = new Random();
            System.Threading.Thread.Sleep(MyRand.Next(50, 500));

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity entity = (Entity)context.InputParameters["Target"];

                IOrganizationServiceFactory serviceFactory =
                    (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                DataverseOperator myOperator = new DataverseOperator(service);

                OptionSetValue OptionReviewNotStarted = new OptionSetValue(695100000);
                OptionSetValue OptionReviewInProgress = new OptionSetValue(695100001);
                OptionSetValue OptionReviewCompleted = new OptionSetValue(695100002);
                try
                {
                    tracingService.Trace($"Inside AutoFail; Depth - {context.Depth}");
                    //DataAccessLogic.LogPlugginAction(myOperator, "AutoFail", context.Depth);

                    Guid requestGuid = new Guid(entity.Attributes["cat_reviewrequestid"].ToString());

                    Entity entReviewRequest = DataAccessLogic.GetEntityDatas(service, "cat_reviewrequest", requestGuid);

                    if (!entReviewRequest.Attributes.ContainsKey("cat_chc_appcheckerstatus"))
                    {
                        tracingService.Trace(" Exit Autofail because of cat_chc_statusimportappcheckerresults field unavailbe in Context");
                        return;
                    }

                    OptionSetValue CurrentOptionSet = (OptionSetValue)entReviewRequest.Attributes["cat_chc_appcheckerstatus"];
                    if (CurrentOptionSet.Value != OptionReviewCompleted.Value)
                    {
                        tracingService.Trace(" Exit Autofail because of cat_chc_statusimportappcheckerresults status is not completed");
                        return;
                    }

                    tracingService.Trace($"Fetching Review record");
                    Entity entReview = DataAccessLogic.GetEntityFromARelatedOne(service, entReviewRequest, "cat_review", "cat_review");
                    Guid reviewGuid = new Guid(entReview.Attributes["cat_reviewid"].ToString());

                    try
                    {
                        System.Threading.Thread.Sleep(11000);

                        tracingService.Trace("Triggering ProcessReviewItemsAutoFail");
                        DataAccessLogic.ProcessReviewItemsAutoFail(myOperator, reviewGuid, tracingService);

                        tracingService.Trace("Triggering ProcessSettingsAutoFail");
                        DataAccessLogic.ProcessSettingsAutoFail(service, myOperator, reviewGuid, DataAccessLogic.GetListSettingMandatory(), tracingService);

                        tracingService.Trace("Triggering ProcessFileSizeAssetsAutoFail");
                        DataAccessLogic.ProcessFileSizeAssetsAutoFail(service, myOperator, reviewGuid, 300, tracingService);

                        tracingService.Trace("Triggering CalculateReviewScore");
                        DataAccessLogic.CalculateReviewScore(myOperator, entReview, tracingService);

                        System.Threading.Thread.Sleep(12000);
                        tracingService.Trace("Updating 'Review Request' entities cat_requeststatus to Completed");
                        DataAccessLogic.UpdateReviewStatus(myOperator, requestGuid, OptionReviewCompleted, "cat_requeststatus", "cat_reviewrequest");
                        tracingService.Trace("Updating 'Review' entities cat_chc_statutimportglobal to Completed");
                        DataAccessLogic.UpdateReviewStatus(myOperator, reviewGuid, OptionReviewCompleted, "cat_chc_statutimportglobal");

                        tracingService.Trace("Triggering PropagateStatusUntilSolution");
                        DataAccessLogic.PropagateStatusUntilSolution(myOperator, entReview, tracingService);
                    }
                    catch (FaultException<OrganizationServiceFault> ex)
                    {
                        DataAccessLogic.LogPlugginAction(myOperator, "auto fail global Error....Catch1 : " + ex.Message, context.Depth);
                        tracingService.Trace($"AutoFailProcessPlugin catch1 Error; Message :{ex.Message} ");
                        throw new InvalidPluginExecutionException("An error occurred in AutoFailProcessPlugin.", ex);
                    }
                }
                catch (Exception ex)
                {
                    DataAccessLogic.LogPlugginAction(myOperator, "auto fail global error....Catch2 : " + ex.Message, context.Depth);
                    tracingService.Trace($"AutoFailProcessPlugin catch2 Error; Message :{ex.Message} ");
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