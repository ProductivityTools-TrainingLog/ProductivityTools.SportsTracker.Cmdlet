using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductivityTools.SportsTracker.AddTraining.Commands
{
    public class General : TrainingCommandBase<AddTrainingCmdlet>
    {
        public General(AddTrainingCmdlet cmdletType) : base(cmdletType)
        {
        }

        protected override bool Condition => true;

        protected override void Invoke()
        {
            base.Cmdlet.Application.AddTraining(this.Cmdlet.Duration,
                this.Cmdlet.TrainingType,
                this.Cmdlet.Date,
                this.Cmdlet.Time,
                this.Cmdlet.Description,
                this.Cmdlet.Distance,
                this.Cmdlet.ImagePath);

            WriteOutput("Training Added");
        }
    }
}
