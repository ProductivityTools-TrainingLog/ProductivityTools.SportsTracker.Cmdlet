using Microsoft.Extensions.Configuration;
using ProductivityTools.MasterConfiguration;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.SportsTracker.ImportTraining
{
    [Cmdlet("Import", "Training")]
    public class ImportTrainingCmdlet : PSCmdlet.PSCmdletPT
    {
        protected override void ProcessRecord()
        {
            WriteOutput("Hello");


            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddMasterConfiguration(force:true).Build();


            var login = configuration["Login"];
            var password = configuration["Password"];
            WriteOutput(login);
            WriteOutput(password);
            base.ProcessRecord();
        }
    }
}
