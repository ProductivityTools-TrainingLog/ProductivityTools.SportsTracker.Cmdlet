using Microsoft.Extensions.Configuration;
using ProductivityTools.MasterConfiguration;
using ProductivityTools.SportsTracker.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography;
using System.Text;

namespace ProductivityTools.SportsTracker.ImportTraining
{
    [Cmdlet("Import", "Training")]
    public class ImportTrainingCmdlet : STCmdlet
    {
        protected override void ProcessRecord()
        {
            string s = @"c:\Users\pwujczyk\Downloads\pawel.gpx";
            byte[] bytes = File.ReadAllBytes(s);

            //FileStream fs = new FileStream(@"c:\Users\pwujczyk\Downloads\pawel.gpx", FileMode.Open, FileAccess.Read);
            //byte[] data = new byte[fs.Length];
            //fs.Read(data, 0, data.Length);
            //fs.Close();
            Invoke2();
            base.Application.ImportGpxFile(bytes);
            base.ProcessRecord();
        }

        private void Invoke2()
        {
            string s = @"c:\Users\pwujczyk\Downloads\2020-11-14%2012_26_11.0.gpx";
            base.Application.ImportGpxFile(s);
        }
    }
}
