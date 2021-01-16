using ProductivityTools.SportsTracker.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.SportsTracker.AddTraining.Commands
{
    class Fitness : PSCmdlet.PSCommandPT<AddTrainingCmdlet>
    {
        public Fitness(AddTrainingCmdlet cmdletType) : base(cmdletType)
        {
        }

        protected override bool Condition => this.Cmdlet.TrainingType == TrainingType.Fitness;

        protected override void Invoke()
        {
            throw new NotImplementedException();
        }
    }
}
