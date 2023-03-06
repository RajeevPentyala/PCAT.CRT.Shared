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
    public class VariablesProcessingPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
        }
    }
}
