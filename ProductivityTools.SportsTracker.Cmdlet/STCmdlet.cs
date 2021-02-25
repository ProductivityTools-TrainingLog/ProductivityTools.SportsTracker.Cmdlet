using Microsoft.Extensions.Configuration;
using ProductivityTools.MasterConfiguration;
using ProductivityTools.SportsTracker.App;
using System;

namespace ProductivityTools.SportsTracker
{
    public abstract class STCmdlet : PSCmdlet.PSCmdletPT
    {
        //maybe move it to command
        public Application Application
        {
            get
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().AddMasterConfiguration(force: true).Build();


                var username = configuration["UserName"];
                var password = configuration["Password"];
                Application app = new Application(username, password);
                return app;
            }
        }
    }
}
