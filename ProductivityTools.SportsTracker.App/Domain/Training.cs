using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.SportsTracker.App.Dto
{
    public class Training
    {
        public DateTime StartDate { get; set; }
        public double Distance { get; set; }
        public TrainingType TrainingType { get; set; }

        public Training(ProductivityTools.SportsTracker.App.Dto.TrainingList.Payload payload)
        {
            this.StartDate = payload.StartDate();
            this.Distance = Math.Round(payload.totalDistance / 1000, 2);
            this.TrainingType = (TrainingType)payload.activityId;
        }
    }
}
