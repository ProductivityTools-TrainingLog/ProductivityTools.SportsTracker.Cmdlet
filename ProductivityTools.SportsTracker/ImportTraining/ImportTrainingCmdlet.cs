using Microsoft.Extensions.Configuration;
using ProductivityTools.MasterConfiguration;
using ProductivityTools.SportsTracker.App;
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
                .AddMasterConfiguration(force: true).Build();


            var username = configuration["UserName"];
            var password = configuration["Password"];
            WriteOutput(username);
            WriteOutput(password);
            Application app = new Application(username, password);
            app.Login(username, password);
            base.ProcessRecord();
        }
    }
}
