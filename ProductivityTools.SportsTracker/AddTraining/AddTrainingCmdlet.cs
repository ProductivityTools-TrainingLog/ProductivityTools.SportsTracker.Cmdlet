using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.SportsTracker.AddTraining
{
    [Cmdlet(VerbsCommon.Add, "Training")]
    public class AddTrainingCmdlet : STCmdlet
    {
        [Parameter]
        public int Minutes { get; set; }

        protected override void ProcessRecord()
        {
            int time = Minutes * 60;
            base.Application.AddTraining(App.Dto.TrainingType.Areobics, "nothing", 120, DateTime.Now);
            base.ProcessRecord();
        }
    }
}
