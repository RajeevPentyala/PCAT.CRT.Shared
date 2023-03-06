using System;
using System.Linq;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using CodeViewerExtractor;
using System.IO;
using Microsoft.PowerPlatform.Formulas.Tools;
using Net.Formulas.Tools.DataverseLib;

namespace Net.Formulas.Tools.Tools
{
    /// <summary>
    /// On Create of cat_reviewrequest(i.e.,ReviewRequest) record
    /// </summary>
    public class AppCheckerResultsProcessingPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            tracingService.Trace("Begin AppcheckerResults : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());

            if (!(context.Depth == 2 && (context.InputParameters.Values.First() as Entity).Attributes["cat_cd_typeoriginereview"].ToString() == "Solution"))
            {
                tracingService.Trace("Returning from depth check");
                return;
            }

            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {

                OptionSetValue OptionReviewNotStarted = new OptionSetValue(695100000);
                OptionSetValue OptionReviewInProgress = new OptionSetValue(695100001);
                OptionSetValue OptionReviewCompleted = new OptionSetValue(695100002);

                Entity entity = (Entity)context.InputParameters["Target"];

                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
                DataverseOperator myOperator = new DataverseOperator(service);

                try
                {
                    //DataAccessLogic.LogPlugginAction(myOperator, "AppCheckerResults", context.Depth);
                    Entity entReview = DataAccessLogic.GetEntityFromARelatedOne(service, entity, "cat_review", "cat_review");
                    Guid reviewGuid = new Guid(entReview["cat_reviewid"].ToString());

                    Entity entityFullReviewRequest = DataAccessLogic.GetEntityDatas(service, "cat_reviewrequest", entity.Id);
                    if (entityFullReviewRequest.Attributes.ContainsKey("cat_requeststatus"))
                    {
                        OptionSetValue reviewRequestStatus = (OptionSetValue)entityFullReviewRequest.Attributes["cat_requeststatus"];

                        if (reviewRequestStatus.Value == OptionReviewCompleted.Value)
                        {
                            tracingService.Trace("AppChecker Results exit : because Request Status to : " + reviewRequestStatus.Value.ToString());
                            DataAccessLogic.LogPlugginAction(myOperator, "AppCheckerResultsProcessing exit : because Request Status is : " + reviewRequestStatus.Value.ToString(), context.Depth);
                        }
                        else
                        {
                            try
                            {
                                tracingService.Trace("Begin LoadMsapp : " + DateTime.Now.ToString("MM/dd/yyy HH:mm:ss.fff"));
                                string uriMsapp = "";
                                if (entReview.Attributes.ContainsKey("cat_msapp_document_uri"))
                                {
                                    uriMsapp = entReview["cat_msapp_document_uri"].ToString();
                                }

                                //DataAccessLogic.LoadApptoSharedVariable(tracingService, context, myOperator, reviewGuid, uriMsapp);
                                string appPayloadBase64 = DataAccessLogic.SyncAppPayloadtoDataverse(tracingService, entReview, myOperator, uriMsapp);
                                CanvasDocument msApp = myOperator.getCanvasDoc(myOperator, reviewGuid, tracingService, "cat_review", "cat_msappfile", uriMsapp, appPayloadBase64);

                                if (msApp == null)
                                {
                                    tracingService.Trace("Exiting as msApp is null");
                                    return;
                                }

                                tracingService.Trace("Processing App Checker Results.... " + DateTime.Now.ToString("MM/dd/yyy HH:mm:ss.fff"));
                                DataAccessLogic.ProcessAppCheckerResults(msApp, myOperator, reviewGuid, tracingService);

                                tracingService.Trace("After Processing App Checker Results.... " + DateTime.Now.ToString("MM/dd/yyy HH:mm:ss.fff"));
                                //System.Threading.Thread.Sleep(5000);

                                tracingService.Trace($"Updating 'Review Request' status to 'Review Completed'");
                                DataAccessLogic.UpdateReviewStatus(myOperator, new Guid(entity.Attributes["cat_reviewrequestid"].ToString()), OptionReviewCompleted, "cat_chc_appcheckerstatus", "cat_reviewrequest");

                                //tracingService.Trace($"Triggering PropagateStatusUntilSolution");
                                //DataAccessLogic.PropagateStatusUntilSolution(myOperator, entReview, tracingService);
                            }
                            catch (FaultException<OrganizationServiceFault> ex)
                            {
                                DataAccessLogic.LogPlugginAction(myOperator, "AppChecker status to Error....Catch1 : " + ex.Message, context.Depth);
                                tracingService.Trace($"Appchecker Setting status to Error; Message :{ex.Message} ");
                                //throw new InvalidPluginExecutionException("An error occurred in AppCheckerResultsProcessingPlugin.", ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DataAccessLogic.LogPlugginAction(myOperator, "AppChecker status to Error....Catch2 : " + ex.Message, context.Depth);
                    tracingService.Trace($"Error in catch 2 of AppCheckerResultsProcessingPlugin: {ex.Message}");
                    //throw;
                }
                finally
                {
                    tracingService.Trace("End AppcheckerResults : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());
                }
            }
        }
    }
}