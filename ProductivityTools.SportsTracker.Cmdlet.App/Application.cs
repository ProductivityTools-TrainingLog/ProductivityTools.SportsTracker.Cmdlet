using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductivityTools.SportsTracker.SDK.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.SportsTracker.App
{
    public class Application
    {
        SDK.SportsTracker SportsTracker;

        public Application(string username, string password, bool verbose)
        {
            this.SportsTracker = new ProductivityTools.SportsTracker.SDK.SportsTracker(username, password, verbose);
        }

        public List<Training> GetTrainingList()
        {
            var trainingList = this.SportsTracker.GetTrainingList();
            return trainingList;
        }

        public void AddTraining(
            int duration,
            TrainingType trainingType,
            DateTime date,
            string time,
            string description,
            int distance,
            string path)
        {
            var Training = new SDK.Model.Training();
            Training.SharingFlags = 19;//public

            Training.Duration = TimeSpan.FromMinutes(duration);
            if (date==DateTime.MinValue) { date = DateTime.Now; }
            Training.StartDate = GetStartDate(date, time);
            Training.TrainingType = trainingType;
            Training.Description = description;
            Training.Distance = distance;

            if (!string.IsNullOrEmpty(path))
            {
                //string s = @"c:\Users\pwujczyk\Desktop\Pamela.jpg";
                byte[] bytes = File.ReadAllBytes(path);
                this.SportsTracker.AddTraining(Training, bytes);
            }
            else
            {
                this.SportsTracker.AddTraining(Training);
            }
        }

        private DateTime GetStartDate(DateTime date, string time)
        {
            if (string.IsNullOrEmpty(time))
            {
                if (date == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return date;
                }
            }
            else
            {
                string[] parts = time.Split(':');
                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);

                int timeInMinutes = hours * 60 + minutes;

                return date.Date.AddMinutes(timeInMinutes);
            }
        }

        private void AddTraining(Training training, byte[] image)
        {
            AddTraining(training, null, image);
        }

    }
}


