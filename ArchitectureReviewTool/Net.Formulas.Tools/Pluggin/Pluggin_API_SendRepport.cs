
using System;
using Microsoft.Xrm.Sdk;
using Net.Formulas.Tools.Classes;
using DataverseLib;
public class Pluggin_API_SendRepport : IPlugin
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
                string input = (string)context.InputParameters["ReviewName"];

                IOrganizationServiceFactory serviceFactory =
                        (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                DataverseOperator myOperator = new DataverseOperator(service);

                if (!string.IsNullOrEmpty(input))
                {
                    SarifExporter MyExporter= new SarifExporter(input);
                    //context.OutputParameters["RepportBody"] = MyExporter.MakeExport(myOperator, service);
                }
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
