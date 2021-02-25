using ProductivityTools.SportsTracker.App.Dto;
using System;
using System.Collections.Generic;
using System.IO;
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
            Training training = new Training();
            training.TrainingType = TrainingType.Fitness;
            training.SharingFlags = 19;//public
            training.Description = this.Cmdlet.Description;
            training.Duration = TimeSpan.FromMinutes(this.Cmdlet.Duration);
            training.StartDate = GetStartDate();
            training.Distance = 0;

            string s = @"c:\Users\pwujczyk\Desktop\Pamela.jpg";
            byte[] bytes = File.ReadAllBytes(s);


            this.Cmdlet.Application.AddTraining(training, bytes);
        }

        private DateTime GetStartDate()
        {
            if (string.IsNullOrEmpty(this.Cmdlet.Time))
            {
                if (this.Cmdlet.Date == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return this.Cmdlet.Date;
                }
            }
            else
            {
                string[] parts = this.Cmdlet.Time.Split(':');
                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);

                int time = hours * 60 + minutes;

                return DateTime.Now.Date.AddMinutes(time);
            }
        }
    }
}
