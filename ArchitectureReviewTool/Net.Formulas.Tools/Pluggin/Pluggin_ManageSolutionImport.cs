
using System;
using System.Linq;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using CodeViewerExtractor;
using System.IO;
using Microsoft.PowerPlatform.Formulas.Tools;
using Net.Formulas.Tools.DataverseLib;
using Net.Formulas.Tools.Solution;
using System.Collections.Generic;

namespace Net.Formulas.Tools.Pluggin
{
    /// <summary>
    /// On Create of cat_rev_solutionrequest (i.e.,Rev_SolutionRequest) record
    /// </summary>
    public class ManageSolutionImport : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {

            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            tracingService.Trace("Begin SolutionImport : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());

            if (context.Depth > 1)
            {
                tracingService.Trace($"Exiting from Depth check; Depth : {context.Depth}");
                return;
            }

            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                Entity TheEntity = (Entity)context.InputParameters["Target"];

                IOrganizationServiceFactory serviceFactory =
                    (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                DataverseOperator myOperator = new DataverseOperator(service);
                Guid reviewGuid = Guid.Empty;
                System.Text.StringBuilder sbrErrorMessage = new System.Text.StringBuilder();
                try
                {
                    Entity entSolutionReview = DataAccessLogic.GetEntityFromARelatedOne(service, TheEntity, "cat_rev_solution_review_request", "cat_rev_solutionreview");
                    reviewGuid = new Guid(entSolutionReview.Attributes["cat_rev_solutionreviewid"].ToString());

                    try
                    {
                        MemoryStream reviewPayloadStream;
                        string typeImport;
                        if (entSolutionReview.Attributes.ContainsKey("cat_file_solutionzip"))
                        {
                            typeImport = "solution";
                            reviewPayloadStream = myOperator.getSolutionZip(myOperator, reviewGuid, "cat_rev_solutionreview", "cat_file_solutionzip", tracingService);
                        }
                        else if (entSolutionReview.Attributes.ContainsKey("cat_file_msapp"))
                        {
                            typeImport = "Apps";
                            reviewPayloadStream = myOperator.getSolutionZip(myOperator, reviewGuid, "cat_rev_solutionreview", "cat_file_msapp", tracingService);
                        }
                        else if (entSolutionReview.Attributes.ContainsKey("cat_appdocumenturi") && entSolutionReview["cat_appdocumenturi"].ToString() != "NA")
                        {
                            tracingService.Trace("Reading AppId Stream");
                            typeImport = "AppUrl";
                            string appDocumentUri = entSolutionReview["cat_appdocumenturi"].ToString();
                            reviewPayloadStream = myOperator.FetchAppStreamContentbyAppID(myOperator, appDocumentUri, tracingService);
                            sbrErrorMessage.Clear();
                            sbrErrorMessage.AppendLine($"Error while processing the Review Request; Provided AppId {appDocumentUri} is invalid");
                        }
                        else
                        {
                            typeImport = "";
                            reviewPayloadStream = null;
                        }

                        if (reviewPayloadStream == null)
                        {
                            tracingService.Trace("No apps found; Setting the Review Request to Error");
                            DataAccessLogic.SetSolutionReviewStatusToError(myOperator, reviewGuid, sbrErrorMessage.Length > 0 ? sbrErrorMessage.ToString() : "No 'Dataverse Solution' or '.msapp' files are provided in the Review. Try creating a new Review with either a valid Dataverse Solution or .msapp files.");
                            return;
                        }

                        tracingService.Trace("Processing Solution Import.... ");
                        SolutionLoader UploadedSolution = new SolutionLoader(reviewPayloadStream, typeImport, string.Empty, tracingService);

                        if (UploadedSolution.ListApps.Count == 0)
                        {
                            tracingService.Trace("No apps found; Setting the Review Request to Error");
                            DataAccessLogic.SetSolutionReviewStatusToError(myOperator, reviewGuid, "No apps found in the uploaded file. Only a valid 'Dataverse Solution' or '.msapp' files are allowed.");
                            return;
                        }

                        // Create 'Rev_Apps', 'cat_review', 'reviewrequest' records
                        //DataAccessLogic.LogPlugginAction(myOperator, "SolutionCreationafterupload", context.Depth);
                        DataAccessLogic.LoadSolutionElements(myOperator, reviewGuid, UploadedSolution, tracingService);
                        //DataAccessLogic.LogPlugginAction(myOperator, "SolutionCreationfin", context.Depth);
                    }
                    catch (Exception ex)
                    {
                        DataAccessLogic.LogPlugginAction(myOperator, "Solution Import Catch 1" + ex.Message, context.Depth);
                        tracingService.Trace($"Error in ManageSolutionImport : {ex.Message}");
                        throw new InvalidPluginExecutionException("An error occurred in Solution Import.", ex);
                    }
                }
                catch (Exception ex)
                {
                    DataAccessLogic.LogPlugginAction(myOperator, "Solution Import Catch 2" + ex.Message, context.Depth);
                    tracingService.Trace($"Outer exception in ManageSolutionImport : {ex.Message}");
                    DataAccessLogic.SetSolutionReviewStatusToError(myOperator, reviewGuid, $"Error while unpacking Solution : {ex.Message}");
                }
                finally
                {
                    tracingService.Trace("End SolutionImport : " + DataAccessLogic.GetTimestamp(DateTime.Now) + ", Context.Depth : " + context.Depth.ToString());
                }
            }
        }
    }
}