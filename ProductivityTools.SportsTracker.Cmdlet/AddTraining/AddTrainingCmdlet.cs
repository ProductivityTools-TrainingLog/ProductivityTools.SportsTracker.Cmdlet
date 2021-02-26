using ProductivityTools.SportsTracker.AddTraining.Commands;
using ProductivityTools.SportsTracker.SDK.Model;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.SportsTracker.AddTraining
{
    [Cmdlet("Add", "Training")]
    public class AddTrainingCmdlet : STCmdlet
    {
        [Parameter(Mandatory = true)]
        public TrainingType TrainingType { get; set; }

        [Parameter(Mandatory = false)]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Duration of the training in minutes")]
        public int Duration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Date when training happened. Format YYYY.MM.DD")]
        public DateTime Date { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Time of the day when training happened, if not provided training will be created with current time. Format HH:MM")]
        public string Time { get; set; }

        [Parameter(Mandatory = false)]
        public int Minutes { get; set; }

        [Parameter(Mandatory = false)]
        public string ImagePath { get; set; }

        [Parameter(Mandatory = false)]
        public int Distance { get; set; }

        public AddTrainingCmdlet()
        {
        }

        protected override void ProcessRecord()
        {
            AddCommand(new General(this));
            base.ProcessCommands();
            base.ProcessRecord();
        }
    }
}
