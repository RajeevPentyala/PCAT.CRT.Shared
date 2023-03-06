
using System;
using System.Linq;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using CodeViewerExtractor;
using System.IO;
using Microsoft.PowerPlatform.Formulas.Tools;
using Net.Formulas.Tools.DataverseLib;

public class Pluggin_API_ImportNewApp : IPlugin
{
    public void Execute(IServiceProvider serviceProvider)
    {
        // Obtain the tracing service
        ITracingService tracingService =
        (ITracingService)serviceProvider.GetService(typeof(ITracingService));

        // Obtain the execution context from the service provider.  
        IPluginExecutionContext context = (IPluginExecutionContext)
            serviceProvider.GetService(typeof(IPluginExecutionContext));

        if (context.MessageName.Equals("API_SendRepport") && context.Stage.Equals(30))
        {

            try
            {
                string AppUri = (string)context.InputParameters["AppUri"];
                string ReviewName = (string)context.InputParameters["ReviewName"];

                IOrganizationServiceFactory serviceFactory =
                        (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                DataverseOperator myOperator = new DataverseOperator(service);
                Guid reviewGuid = myOperator.CreateNewReview(myOperator, ReviewName);

                CanvasDocument msApp = myOperator.getCanvasDoc(myOperator, reviewGuid, tracingService, "cat_review", "cat_msappfile", AppUri);
                if (msApp == null) return;
            }
            catch (Exception ex)
            {
                tracingService.Trace("Pluggin_API_SendRepport: {0}", ex.ToString());
                throw new InvalidPluginExecutionException("An error occurred in Sample_CustomAPIExample.", ex);
            }
        }
        else
        {
            tracingService.Trace("Pluggin_API_SendRepport plug-in is not associated with the expected message or is not registered for the main operation.");
        }
    }
}
