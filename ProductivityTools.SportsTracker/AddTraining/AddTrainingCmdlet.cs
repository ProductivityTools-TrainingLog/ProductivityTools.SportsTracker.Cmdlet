using ProductivityTools.SportsTracker.App.Dto;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.SportsTracker.AddTraining
{
    [Cmdlet("Add", "Training")]
    public class AddTrainingCmdlet : STCmdlet
    {
        [Parameter]
        public TrainingType TrainingType { get; set; }

        public AddTrainingCmdlet()
        {
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }
    }
}
