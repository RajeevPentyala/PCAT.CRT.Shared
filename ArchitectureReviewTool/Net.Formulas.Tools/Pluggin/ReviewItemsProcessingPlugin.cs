using System;
using System.Linq;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using CodeViewerExtractor;
using System.IO;
using Microsoft.PowerPlatform.Formulas.Tools;
using Net.Formulas.Tools.DataverseLib;
using System.Collections.Generic;

namespace Net.Formulas.Tools.Tools
{
    /// <summary>
    /// On Create of cat_reviewrequest(i.e.,ReviewRequest) record
    /// </summary>
    public class ReviewItemsProcessingPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {

            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));


            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            tracingService.Trace("Begin ReviewItems : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());

            IOrganizationServiceFactory serviceFactory =
                        (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            DataverseOperator myOperator = new DataverseOperator(service);
            DataAccessLogic.LogPlugginAction(myOperator, "ReviewItems avant", context.Depth);

            if (!(context.Depth == 2 && (context.InputParameters.Values.First() as Entity).Attributes["cat_cd_typeoriginereview"].ToString() == "Solution"))
            {
                tracingService.Trace($"Exiting from depth check; Depth : {context.Depth}");
                return;
            }

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                OptionSetValue OptionReviewCompleted = new OptionSetValue(695100002);

                try
                {
                    Entity entity = (Entity)context.InputParameters["Target"];
                    //DataAccessLogic.LogPlugginAction(myOperator, "ReviewItems apres", context.Depth);

                    Entity UpdatedEntity = DataAccessLogic.GetEntityFromARelatedOne(service, entity, "cat_review", "cat_review");
                    Guid reviewGuid = new Guid(UpdatedEntity.Attributes["cat_reviewid"].ToString());

                    Entity entityFullReviewRequest = DataAccessLogic.GetEntityDatas(service, "cat_reviewrequest", entity.Id);
                    if (entityFullReviewRequest.Attributes.ContainsKey("cat_requeststatus"))
                    {
                        OptionSetValue CurrentOptionSet = (OptionSetValue)entityFullReviewRequest.Attributes["cat_requeststatus"];

                        if (CurrentOptionSet.Value == OptionReviewCompleted.Value)
                        {
                            tracingService.Trace("ReviewItemsProcessing exit : because Request Status to : " + CurrentOptionSet.Value.ToString());
                            DataAccessLogic.LogPlugginAction(myOperator, "ReviewItemsProcessing exit : because Request Status is : " + CurrentOptionSet.Value.ToString(), context.Depth);
                        }
                        else
                        {
                            try
                            {
                                // Fetch Active Patterns from "cat_pattern" table
                                tracingService.Trace("Fetching Active Patterns from 'cat_pattern' table");
                                List<Entity> activePatterns = DataAccessLogic.GetActivePatterns(myOperator);

                                if (activePatterns != null && activePatterns.Count > 0)
                                {
                                    tracingService.Trace($"Creating 'Review Items' by matching {activePatterns.Count} Patterns");
                                    DataAccessLogic.CreateandAutoPassReviewItems(service, reviewGuid, activePatterns, tracingService);
                                }
                                else
                                {
                                    tracingService.Trace($"No Active Patterns Found");
                                }

                                // Update Review's 'cat_chc_reviewitemstatus' status
                                DataAccessLogic.UpdateReviewStatus(myOperator, new Guid(entity.Attributes["cat_reviewrequestid"].ToString()), OptionReviewCompleted, "cat_chc_reviewitemstatus", "cat_reviewrequest");
                            }
                            catch (FaultException<OrganizationServiceFault> ex)
                            {
                                DataAccessLogic.LogPlugginAction(myOperator, "ReviewItemsProcessingPlugin status to Error....Catch1 : " + ex.Message, context.Depth);
                                tracingService.Trace($"Error in catch 1 of ReviewItemsProcessingPlugin: {ex.Message}");
                                throw new InvalidPluginExecutionException("An error occurred in ReviewItemsProcessingPlugin.", ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DataAccessLogic.LogPlugginAction(myOperator, "ReviewItemsProcessingPlugin status to Error....Catch2 : " + ex.Message, context.Depth);
                    tracingService.Trace($"Error in catch 2 of ReviewItemsProcessingPlugin: {ex.Message}");
                    throw;
                }
            }
        }
    }
}