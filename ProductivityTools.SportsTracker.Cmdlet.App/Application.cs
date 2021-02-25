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

        public Application(string username, string password)
        {
            this.SportsTracker = new ProductivityTools.SportsTracker.SDK.SportsTracker(username, password);
        }

        public List<Training> GetTrainingList()
        {
            var trainingList = this.SportsTracker.GetTrainingList();
            return trainingList;
        }

        public void AddTraining(Training training)
        {
            AddTraining(training, null, null);
        }


        public void AddTraining(Training training, byte[] gpxFile, byte[] image)
        {

        }

        public void AddTraining(Training training, byte[] image)
        {
            AddTraining(training, null, image);
        }

    }
}


