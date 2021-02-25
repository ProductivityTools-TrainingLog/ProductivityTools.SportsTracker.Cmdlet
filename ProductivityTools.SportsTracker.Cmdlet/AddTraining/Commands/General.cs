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
            var Training = new SDK.Model.Training();
            Training.SharingFlags = 19;//public

            Training.Duration = TimeSpan.FromMinutes(this.Cmdlet.Duration);
            Training.StartDate = GetStartDate();
            Training.TrainingType = this.Cmdlet.TrainingType;
            Training.Description = this.Cmdlet.Description;
            Training.Distance = this.Cmdlet.Distance;

            if (!string.IsNullOrEmpty(this.Cmdlet.ImagePath))
            {
                //string s = @"c:\Users\pwujczyk\Desktop\Pamela.jpg";
                byte[] bytes = File.ReadAllBytes(this.Cmdlet.ImagePath);
                this.Cmdlet.Application.AddTraining(Training, bytes);
            }
            else
            {
                this.Cmdlet.Application.AddTraining(Training);
            }
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
