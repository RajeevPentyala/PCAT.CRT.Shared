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
    /// Custom API to read and load patterns.
    /// </summary>
    public class PatternRefreshAPI : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));


            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            IOrganizationServiceFactory serviceFactory =
                        (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            if (context.MessageName.Equals("cat_patternrefreshapi") && context.Stage.Equals(30))
            {
                try
                {
                    DataverseOperator myOperator = new DataverseOperator(service);

                    throw new InvalidPluginExecutionException("Manually thrown exception");

                    // Fetch Active Patterns from "cat_pattern" table
                    tracingService.Trace("Fetching Active Patterns from 'cat_pattern' table");
                    List<Entity> activePatterns = DataAccessLogic.GetActivePatterns(myOperator);

                    if (activePatterns != null)
                    {
                        tracingService.Trace($"Fetched {activePatterns.Count} no of Active Patterns from 'cat_pattern' table");
                    }
                    else
                    {
                        tracingService.Trace($"Active Patterns collection is null");
                    }

                    // Match the AppVersion with Web Resource 'App Version' and refreshes Patterns
                    DataAccessLogic.ProcessInitialLoading(myOperator, activePatterns, tracingService);
                }
                catch (Exception ex)
                {
                    tracingService.Trace($"Error in PatternRefreshAPI: {ex.Message}");
                    throw;
                }
            }
        }
    }
}