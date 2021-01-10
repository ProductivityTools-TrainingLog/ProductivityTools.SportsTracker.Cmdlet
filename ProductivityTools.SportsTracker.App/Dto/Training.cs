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

    }
}
