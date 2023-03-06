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
    public class MediaFilesProcessingplugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {

            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));


            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            tracingService.Trace("Begin MediaFiles : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());

            if (!(context.Depth == 2 && (context.InputParameters.Values.First() as Entity).Attributes["cat_cd_typeoriginereview"].ToString() == "Solution"))
            {
                tracingService.Trace($"Exiting from depth check; Depth : {context.Depth}");
                return;
            }

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

                    DataAccessLogic.LogPlugginAction(myOperator, "Medias", context.Depth);

                    Entity UpdatedEntity = DataAccessLogic.GetEntityFromARelatedOne(service, entity, "cat_review", "cat_review");
                    Guid reviewGuid = new Guid(UpdatedEntity.Attributes["cat_reviewid"].ToString());

                    Entity entityFullReviewRequest = DataAccessLogic.GetEntityDatas(service, "cat_reviewrequest", entity.Id);
                    if (entityFullReviewRequest.Attributes.ContainsKey("cat_requeststatus"))
                    {
                        OptionSetValue CurrentOptionSet = (OptionSetValue)entityFullReviewRequest.Attributes["cat_requeststatus"];

                        if (CurrentOptionSet.Value == OptionReviewCompleted.Value)
                        {
                            tracingService.Trace("Media Files Processing exit : because Request Status to : " + CurrentOptionSet.Value.ToString());
                            DataAccessLogic.LogPlugginAction(myOperator, "MediaFilesProcessing exit : because Request Status is : " + CurrentOptionSet.Value.ToString(), context.Depth);
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

                                tracingService.Trace(" Processing MediaFiles.... ");
                                DataAccessLogic.ProcessMediaFiles(msApp, myOperator, reviewGuid, tracingService);
                            }
                            catch (FaultException<OrganizationServiceFault> ex)
                            {
                                DataAccessLogic.LogPlugginAction(myOperator, "MediaFilesProcessing status to Error....Catch1 : " + ex.Message, context.Depth);
                                tracingService.Trace($"Error in catch 1 of MediaFilesProcessingPlugin: {ex.Message}");
                                throw new InvalidPluginExecutionException("An error occurred in MediaFilesProcessingPlugin.", ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DataAccessLogic.LogPlugginAction(myOperator, "MediaFilesProcessing status to Error....Catch2 : " + ex.Message, context.Depth);
                    tracingService.Trace($"Error in catch 2 of MediaFilesProcessingPlugin: {ex.Message}");
                    throw;
                }
                finally
                {
                    tracingService.Trace("End MediaFiles : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());
                }
            }
        }
    }
}