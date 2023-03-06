using System;
using System.Linq;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using CodeViewerExtractor;
using System.IO;
using Microsoft.PowerPlatform.Formulas.Tools;
using Net.Formulas.Tools.DataverseLib;

namespace Net.Formulas.Tools.Pluggin
{
    /// <summary>
    /// On Create of cat_reviewrequest(i.e.,ReviewRequest) record
    /// </summary>
    public class DataSourcesProcessingPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {

            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            tracingService.Trace("Begin Datasources Processing : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity entity = (Entity)context.InputParameters["Target"];

                OptionSetValue OptionReviewNotStarted = new OptionSetValue(695100000);
                OptionSetValue OptionReviewInProgress = new OptionSetValue(695100001);
                OptionSetValue OptionReviewCompleted = new OptionSetValue(695100002);

                string typeOriginReview = string.Empty;
                if (entity.Attributes.Contains("cat_cd_typeoriginereview") && entity["cat_cd_typeoriginereview"] != null)
                {
                    typeOriginReview = entity["cat_cd_typeoriginereview"].ToString();
                }

                if (!(context.Depth == 2 && typeOriginReview.ToLowerInvariant() == "solution"))
                {
                    tracingService.Trace($"Exiting from depth check; Depth : {context.Depth}");
                    return;
                }

                IOrganizationServiceFactory serviceFactory =
                    (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                DataverseOperator myOperator = new DataverseOperator(service);

                try
                {
                    DataAccessLogic.LogPlugginAction(myOperator, "Datasources", context.Depth);

                    Entity UpdatedEntity = DataAccessLogic.GetEntityFromARelatedOne(service, entity, "cat_review", "cat_review");
                    Guid reviewGuid = new Guid(UpdatedEntity.Attributes["cat_reviewid"].ToString());

                    Entity entityFullReviewRequest = DataAccessLogic.GetEntityDatas(service, "cat_reviewrequest", entity.Id);

                    if (entityFullReviewRequest.Attributes.ContainsKey("cat_requeststatus"))
                    {

                        OptionSetValue CurrentOptionSet = (OptionSetValue)entityFullReviewRequest.Attributes["cat_requeststatus"];

                        if (CurrentOptionSet.Value == OptionReviewCompleted.Value)
                        {
                            tracingService.Trace("Datasources exit : because Request Status to : " + CurrentOptionSet.Value.ToString());
                            DataAccessLogic.LogPlugginAction(myOperator, "DatasourcesProcessing exit : because Request Status is : " + CurrentOptionSet.Value.ToString(), context.Depth);
                        }
                        else
                        {
                            try
                            {
                                string uriMsapp = "";
                                if (UpdatedEntity.Attributes.ContainsKey("cat_msapp_document_uri")) uriMsapp = UpdatedEntity["cat_msapp_document_uri"].ToString();

                                //DataAccessLogic.LoadApptoSharedVariable(tracingService, context, myOperator, reviewGuid, uriMsapp);
                                string appPayloadBase64 = DataAccessLogic.SyncAppPayloadtoDataverse(tracingService, UpdatedEntity, myOperator, uriMsapp);
                                CanvasDocument msApp = myOperator.getCanvasDoc(myOperator, reviewGuid, tracingService, "cat_review", "cat_msappfile", uriMsapp, appPayloadBase64);

                                if (msApp == null)
                                {
                                    tracingService.Trace("Exiting as msApp is null");
                                    return;
                                }

                                tracingService.Trace("Processing Data Files .... ");
                                DataAccessLogic.ProcessDataFiles(msApp, myOperator, reviewGuid);
                            }
                            catch (FaultException<OrganizationServiceFault> ex)
                            {
                                DataAccessLogic.LogPlugginAction(myOperator, "Datasources status to Error....Catch1 : " + ex.Message, context.Depth);
                                tracingService.Trace($"Error in catch 1 of DataSourcesProcessingPlugin: {ex.Message}");
                                throw new InvalidPluginExecutionException("An error occurred in DataSourcesProcessingPlugin.", ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DataAccessLogic.LogPlugginAction(myOperator, "Datasources status to Error....Catch2 : " + ex.Message, context.Depth);
                    tracingService.Trace($"Error in catch 2 of DataSourcesProcessingPlugin: {ex.Message}");
                    throw;
                }
                finally
                {
                    tracingService.Trace("End DataSources processing : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());
                }
            }
        }
    }
}