using Microsoft.Extensions.Configuration;
using ProductivityTools.MasterConfiguration;
using ProductivityTools.SportsTracker.App;
using System;
using System.Management.Automation;

namespace ProductivityTools.SportsTracker
{
    public abstract class STCmdlet : PSCmdlet.PSCmdletPT
    {
        [Parameter(Mandatory = false)]
        public string Login { get; set; }

        [Parameter(Mandatory = false)]
        public string Password { get; set; }

        //maybe move it to command
        public Application Application
        {
            get
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().AddMasterConfiguration(force: true).Build();
                var username = string.IsNullOrEmpty(Login) ? configuration["UserName"] : Login;
                var password = string.IsNullOrEmpty(Password) ? configuration["Password"] : Password;
                bool verbose = this.MyInvocation.BoundParameters.ContainsKey("Verbose");
                Application app = new Application(username, password, verbose);
                return app;
            }
        }
    }
}
