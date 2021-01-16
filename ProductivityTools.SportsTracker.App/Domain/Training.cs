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

        public string Description { get; set; }
        public int EnergyConsumption { get; set; }
        public int SharingFlags { get; set; }

        public long StartTime
        {
            get
            {
                return 0;
            }
        }

        public int TotalTime
        {
            get
            {
                return 0;
            }
        }

        public int TotalDistance
        {
            get
            {
                return (int)Distance * 1000;
            }
        }


        public Training(ProductivityTools.SportsTracker.App.Dto.TrainingList.Payload payload)
        {
            this.StartDate = payload.StartDate();
            this.Distance = Math.Round(payload.totalDistance / 1000, 2);
            this.TrainingType = (TrainingType)payload.activityId;
        }
    }
}
