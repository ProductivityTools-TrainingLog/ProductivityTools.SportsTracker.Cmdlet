using Newtonsoft.Json;
using ProductivityTools.SportsTracker.App.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace ProductivityTools.SportsTracker.Endomondo
{
    public class EndomondoImport
    {
        public string Path { get; set; }

        public EndomondoImport(string path)
        {
            this.Path = path;
        }

        public void Import()
        {
            List<EndoMondoTraining> endomondoTrainings = GetEndomondoTrainings();
            foreach (var endomondoTraining in endomondoTrainings)
            {
                AddTraining(endomondoTraining);
            }
        }

        private void AddTraining(EndoMondoTraining endomondoTraining)
        {
            //Training training = new Training();
            //training.TrainingType = TrainingType.Fitness;
            //training.SharingFlags = 19;//public
            //training.Description = this.Cmdlet.Description;
            //training.Duration = TimeSpan.FromMinutes(this.Cmdlet.Duration);
            //training.StartDate = GetStartDate();
            //training.Distance = 0;

            //string s = @"c:\Users\pwujczyk\Desktop\Pamela.jpg";
            //byte[] bytes = File.ReadAllBytes(s);


            //this.Cmdlet.Application.AddTraining(training, bytes);
        }

        private List<EndoMondoTraining> GetEndomondoTrainings()
        {
            List<EndoMondoTraining> trainings = new List<EndoMondoTraining>();
            var files = Directory.GetFiles(this.Path, "*.json");
            foreach (var file in files)
            {
                List<string> pictures = new List<string>();
                bool points = false;
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();

                    if (json.Contains("pictures"))
                    {
                        int picturesplace = json.IndexOf("pictures");

                        var picturesJson = "{" + json.Substring(picturesplace);
                        string pattern = @"\w*(resources/\w*/\w*/\w*/\w*/\w*.\w*)\w*";
                        Regex rg = new Regex(pattern);
                        var xxxxx = rg.Matches(picturesJson);
                        pictures = xxxxx.Cast<Match>().Select(x => x.Value).ToList();

                        json = json.Substring(0, picturesplace - 2) + "]";
                    }


                    if (json.Contains("tags"))
                    {
                        int picturesplace = json.IndexOf("tags");
                        json = json.Substring(0, picturesplace - 2) + "]";

                    }

                    if (json.Contains("points"))
                    {
                        int picturesplace = json.IndexOf("points");
                        json = json.Substring(0, picturesplace - 2) + "]";
                        points = true;
                    }

                    json = json.Replace("{", "");
                    json = json.Replace("}", "");
                    json = json.Replace("[", "{");
                    json = json.Replace("]", "}");

                    var item = JsonConvert.DeserializeObject<EndoMondoTraining>(json);
                    item.Pictures = pictures;
                    item.GPX = points;
                    trainings.Add(item);

                    Console.WriteLine($"{item.name} {item.sport} {item.start_time}");
                }
            }
            return trainings;
        }
    }
}
