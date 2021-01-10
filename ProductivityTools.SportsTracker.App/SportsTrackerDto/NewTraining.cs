using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.SportsTracker.App.SportsTrackerDto.NewTraining
{
    public class Rootobject 
    {
        public int activityId { get; set; }
        public double startTime { get; set; }
        public string description { get; set; }
        public int sharingFlags { get; set; }
        public int totalDistance { get; set; }
        public int energy { get; set; }
        public int duration { get; set; }
        public int timeZoneOffset { get; set; }
    }

}
