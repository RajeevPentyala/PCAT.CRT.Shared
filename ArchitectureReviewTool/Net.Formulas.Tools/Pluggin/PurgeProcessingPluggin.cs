using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using Net.Formulas.Tools.DataverseLib;

namespace Net.Formulas.Tools.Pluggin
{
    /// <summary>
    /// On Delete of cat_reviewrequest(i.e.,ReviewRequest) record
    /// </summary>
    public class PurgeProcessingPluggin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {

            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));


            tracingService.Trace("Begin Review purge : " + DataAccessLogic.GetTimestamp(DateTime.Now));
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            if (context.Depth > 1) return;

            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is EntityReference)
            {

                try
                {

                    EntityReference entity = (EntityReference)context.InputParameters["Target"];

                    IOrganizationServiceFactory serviceFactory =
                        (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                    IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                    DataverseOperator myOperator = new DataverseOperator(service);
                    Guid reviewGuid = entity.Id;//new Guid(entity.Attributes["cat_reviewid"].ToString());

                    try
                    {

                        tracingService.Trace(" Processing review purge .... ");
                        DataAccessLogic.CleanExistingTables(myOperator, reviewGuid);

                        tracingService.Trace("End of Review purge : " + DataAccessLogic.GetTimestamp(DateTime.Now));

                    }
                    catch (FaultException<OrganizationServiceFault> ex)
                    {

                        throw new InvalidPluginExecutionException("An error occurred in review purge.", ex);
                    }

                }
                catch (Exception ex)
                {

                    tracingService.Trace("FollowUpPlugin: {0}", ex.ToString());
                    throw;
                }
            }
        }

    }

}