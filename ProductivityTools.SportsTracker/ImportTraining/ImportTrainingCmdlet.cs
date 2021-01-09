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
            base.ProcessRecord();
        }
    }
}
