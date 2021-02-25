﻿using ProductivityTools.SportsTracker.AddTraining.Commands;
using ProductivityTools.SportsTracker.App.Dto;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.SportsTracker.AddTraining
{
    [Cmdlet("Add", "Training")]
    public class AddTrainingCmdlet : STCmdlet
    {
        [Parameter]
        public TrainingType TrainingType { get; set; }

        [Parameter]
        public string Description { get; set; }

        [Parameter(HelpMessage = "Duration in minutes")]
        public int Duration { get; set; }

        [Parameter(HelpMessage = "Date of the training")]
        public DateTime Date { get; set; }

        [Parameter(HelpMessage = "Time of the training, it will be created in the same day as today. Format HH:MM")]
        public string Time { get; set; }

        [Parameter]
        public int Minutes { get; set; }

        public AddTrainingCmdlet()
        {
        }

        protected override void ProcessRecord()
        {
            AddCommand(new Fitness(this));
            base.ProcessCommands();
            base.ProcessRecord();
        }
    }
}
