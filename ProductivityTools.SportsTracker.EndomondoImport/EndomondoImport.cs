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
            //List<EndoMondoTraining> endomondoTrainings = GetEndomondoTrainings();
            foreach (var endomondoTraining in GetEndomondoTrainings())
            {
                AddTraining(endomondoTraining);
            }
        }

        private void AddTraining(EndoMondoTraining endomondoTraining)
        {
            Training training = new Training();
            training.TrainingType = GetSport(endomondoTraining.sport);
            training.SharingFlags = 19;
            training.Description = endomondoTraining.name;
            training.Duration = TimeSpan.FromSeconds(endomondoTraining.duration_s);
            training.StartDate = DateTime.Parse(endomondoTraining.start_time);
            training.Distance = endomondoTraining.distance_km * 1000;

            string s = @"c:\Users\pwujczyk\Desktop\Pamela.jpg";
            byte[] bytes = File.ReadAllBytes(s);


            //this.Cmdlet.Application.AddTraining(training, bytes);
        }

        private TrainingType GetSport(string sport)
        {
            switch (sport)
            {
                case "SWIMMING": return TrainingType.PoolSwimming;
                case "WEIGHT_TRAINING": return TrainingType.PoolSwimming;
                case "TREADMILL_RUNNING": return TrainingType.Treadmill;
                case "AEROBICS": return TrainingType.Fitness;
                case "BADMINTON": return TrainingType.Badminton;
                case "SQUASH": return TrainingType.Badminton;
                case "DANCING": return TrainingType.Dancing;
                case "ROLLER_SKATING": return TrainingType.RollerSkating;
                case "PILATES": return TrainingType.Fitness;
                case "CLIMBING": return TrainingType.Fitness;
                case "OTHER": return TrainingType.Other;
                case "ROWING":  return TrainingType.Rowing;
                case "YOGA": return TrainingType.Yoga;
                case "SKIING_CROSS_COUNTRY": return TrainingType.CrossCountrySkiing;
                case "FITNESS_WALKING": return TrainingType.NorticWalking;
                case "KAYAKING": return TrainingType.Kayaking;
                case "CYCLING_TRANSPORTATION": return TrainingType.Cycling;
                case "SKIING_DOWNHILL": return TrainingType.AlpineSkiing;
                case "RUNNING": return TrainingType.Running;
                case "HIKING": return TrainingType.Hiking;
                case "WALKING": return TrainingType.Walking;
                case "ORIENTEERING": return TrainingType.Orienteering;
                case "TENNIS": return TrainingType.Tennis;
                case "GYMNASTICS": return TrainingType.Fitness;
                case "MOUNTAIN_BIKING": return TrainingType.MountainBiking;
                case "RIDING": return TrainingType.HorsebackRiding;
                case "ROLLER_SKIING": return TrainingType.RollerSkating;
                case "CYCLING_SPORT":return TrainingType.Cycling;
                case "TABLE_TENNIS": return TrainingType.TableTennis;
                case "SKATEBOARDING": return TrainingType.Skateboarding;
                case "STRETCHING": return TrainingType.Stretching;
                case "ROWING_INDOOR": return TrainingType.Rowing;
                case "ICE_SKATING": return TrainingType.IceSkating;
                case "CROSS_TRAINING": return TrainingType.CrossFit;
                case "STAIR_CLIMBING": return TrainingType.Other;
                case "ROPE_JUMPING": return TrainingType.Other;
                case "MARTIAL_ARTS": return TrainingType.MatirialArts;
                case "SOCCER": return TrainingType.Soccer;
                case "RUNNING_TRAIL": return TrainingType.TrailRunning;
                case "SURFING": return TrainingType.Surfing;



                default: throw new Exception();
            }
        }

        private IEnumerable<EndoMondoTraining> GetEndomondoTrainings()
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
                    yield return item;
                    Console.WriteLine($"{item.name}");
                }
            }
           // return trainings;
        }
    }
}
