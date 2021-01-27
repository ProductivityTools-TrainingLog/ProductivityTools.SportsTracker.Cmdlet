using ProductivityTools.SportsTracker.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.SportsTracker.AddTraining.Commands
{
    public abstract class TrainingCommandBase<T> : PSCmdlet.PSCommandPT<AddTrainingCmdlet>
    {
        public TrainingCommandBase(AddTrainingCmdlet cmdletType) : base(cmdletType) { }  
    }
}
