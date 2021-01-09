using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.SportsTracker.GetTrainings
{
    [Cmdlet("Get", "Trainings")]
    public class GetTrainingCmdlet : STCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteOutput("Hello TrainingList");
            base.Application.GetTrainingList();
            base.ProcessRecord();
        }
    }
}
