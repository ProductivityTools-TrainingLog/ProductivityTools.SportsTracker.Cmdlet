using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ProductivityTools.SportsTracker.App.Dto
{
    public class Training
    {
        public DateTime StartDate { get; set; }
        public double Distance { get; set; }
        public TrainingType TrainingType { get; set; }
        public TimeSpan Duration { get; set; }

        public string Description { get; set; }
        public int EnergyConsumption { get; set; }
        public int SharingFlags { get; set; }

        public long StartTime
        {
            get
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var result= Convert.ToInt64((StartDate - epoch).TotalSeconds);
                return result*1000;
            }
        }

        public int TotalTime
        {
            get
            {
                var result = Duration.TotalSeconds;
                return (int)result;
            }
        }

        public int TotalDistance
        {
            get
            {
                return (int)Distance * 1000;
            }
        }

        public Training()
        { }


        public Training(ProductivityTools.SportsTracker.App.Dto.TrainingList.Payload payload)
        {
            this.StartDate = payload.StartDate();
            this.Distance = Math.Round(payload.totalDistance / 1000, 2);
            this.TrainingType = (TrainingType)payload.activityId;
        }
    }
}
