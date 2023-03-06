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
    /// On Create of cat_rev_screens(i.e.,Rev_Screens) record
    /// </summary>
    public class ControlProcessingPluggin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            string nameScreen = "";
            string typescreen;
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            Entity targetEntity = (Entity)context.InputParameters["Target"];


            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            DataverseOperator myOperator = new DataverseOperator(service);
            tracingService.Trace("Begin Screen controls creation : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());
            if (context.Depth != 3)
            {
                tracingService.Trace($"Exiting due to depth check; Depth : {context.Depth}");
                return;
            }

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity postImageReviewScreens = null;
                //if (context.PostEntityImages != null && context.PostEntityImages.Contains("postImageRevScreens") && context.PostEntityImages["postImageRevScreens"] is Entity)
                //{
                //    postImageReviewScreens = context.InputParameters["Target"] as Entity;
                //}

                try
                {
                    Guid reviewScreenGuid = new Guid(targetEntity.Attributes["cat_rev_screensid"].ToString());

                    // Read from Review Screen record from Post Image if exists
                    Entity entUpdatedReviewScreen = postImageReviewScreens ?? DataAccessLogic.GetEntityDatas(service, "cat_rev_screens", reviewScreenGuid);
                    nameScreen = entUpdatedReviewScreen.Attributes["cat_lb_namescreen"].ToString();
                    typescreen = entUpdatedReviewScreen.Attributes["cat_cd_typeelement"].ToString();
                    Guid reviewGuid = ((EntityReference)entUpdatedReviewScreen.Attributes["cat_rel_screen_review"]).Id;
                    Entity entUpdatedReview = DataAccessLogic.GetEntityDatas(service, "cat_review", reviewGuid);

                    try
                    {
                        tracingService.Trace("Begin controls for screen : " + nameScreen);

                        // Clear BulkRecordstoCreate collection
                        //DataAccessLogic.BulkRecordstoCreate.Clear();

                        //DataAccessLogic.LogPlugginAction(myOperator, "Controls of Screen " + nameScreen, context.Depth);

                        string uriMsapp = "";
                        if (entUpdatedReview.Attributes.ContainsKey("cat_msapp_document_uri")) uriMsapp = entUpdatedReview["cat_msapp_document_uri"].ToString();

                        tracingService.Trace("Triggering SyncAppPayloadtoDataverse");
                        //DataAccessLogic.LoadApptoSharedVariable(tracingService, context, myOperator, reviewGuid, uriMsapp);
                        string appPayloadBase64 = DataAccessLogic.SyncAppPayloadtoDataverse(tracingService, entUpdatedReview, myOperator, uriMsapp);
                        tracingService.Trace("Triggering GetCanvasDoc");
                        CanvasDocument msApp = myOperator.getCanvasDoc(myOperator, reviewGuid, tracingService, "cat_review", "cat_msappfile", uriMsapp, appPayloadBase64);

                        if (msApp == null)
                        {
                            tracingService.Trace($"msApp of {nameScreen} is null. Exiting.");
                            return;
                        }

                        if (typescreen == "Screen")
                        {
                            tracingService.Trace("Loading done, begin import for screen : " + nameScreen);
                            DataAccessLogic.ProcessScreenControls(myOperator, msApp._screens[nameScreen], reviewGuid, reviewScreenGuid, msApp, tracingService);
                        }
                        else
                        {
                            tracingService.Trace("Loading done, begin import component for : " + nameScreen);
                            DataAccessLogic.ProcessScreenControls(myOperator, msApp._components[nameScreen], reviewGuid, reviewScreenGuid, msApp, tracingService);
                        }

                        //tracingService.Trace($"Bulk creating Controls and Property Codes; Count {DataAccessLogic.BulkRecordstoCreate.Count}");
                        //if (DataAccessLogic.BulkRecordstoCreate.Count > 0)
                        //{
                        //    DataAccessLogic.BulkCreateRecords(myOperator, tracingService, DataAccessLogic.BulkRecordstoCreate);
                        //}
                    }
                    catch (FaultException<OrganizationServiceFault> ex)
                    {
                        DataAccessLogic.LogPlugginAction(myOperator, "Controls of Screen Catch One " + nameScreen + " : " + ex.Message, context.Depth);
                        tracingService.Trace($"Error in Catch 1 of ControlProcessingPluggin. Message {ex.Message}");
                        throw ex;
                    }

                }
                catch (Exception ex)
                {
                    DataAccessLogic.LogPlugginAction(myOperator, "Controls of Screen Catch 2 " + nameScreen + " : " + ex.Message, context.Depth);
                    tracingService.Trace($"Error in Catch 2 of ControlProcessingPluggin. Message {ex.Message}");
                    throw;
                }
                finally
                {
                    tracingService.Trace("End Screen " + nameScreen + " controls creation : " + DataAccessLogic.GetTimestamp(DateTime.Now));
                }
            }
        }
    }
}