using ProductivityTools.SportsTracker.App.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductivityTools.SportsTracker.AddTraining.Commands
{
    //class Fitness : TrainingCommandBase<AddTrainingCmdlet>
    //{
    //    public Fitness(AddTrainingCmdlet cmdletType) : base(cmdletType)
    //    {
    //    }

    //    protected override bool Condition => this.Cmdlet.TrainingType == TrainingType.Fitness;

    //    protected override void Invoke()
    //    {
    //        Training training = new Training();
    //        training.TrainingType = this.Cmdlet.TrainingType;
    //        training.SharingFlags = 19;//public
    //        training.Description = this.Cmdlet.Description;
    //        training.Duration = TimeSpan.FromMinutes(this.Cmdlet.Duration);
    //        training.StartDate = GetStartDate();
    //        training.Distance = 0;

    //        if (!string.IsNullOrEmpty(this.Cmdlet.ImagePath))
    //        {
    //            //string s = @"c:\Users\pwujczyk\Desktop\Pamela.jpg";
    //            byte[] bytes = File.ReadAllBytes(this.Cmdlet.ImagePath);
    //            this.Cmdlet.Application.AddTraining(training, bytes);
    //        }
    //        else
    //        {
    //            this.Cmdlet.Application.AddTraining(training);
    //        }
    //    }
    //}
}
