using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.SportsTracker.GetTrainings
{
    [Cmdlet("Get", "Trainings")]
    public class GetTrainingCmdlet : STCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteVerbose("Hello TrainingList");
            var trainings = base.Application.GetTrainingList();
            foreach(var training in trainings.OrderBy(x=>x.StartDate))
            {
                this.WriteObject(training);
            }
            base.ProcessRecord();
        }
    }
}
