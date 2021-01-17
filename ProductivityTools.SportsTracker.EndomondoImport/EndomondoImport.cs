using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
            GetTrainings();
        }

        private void GetTrainings()
        {
            List<EndoMondoTraining> trainings = new List<EndoMondoTraining>();
            var files = Directory.GetFiles(this.Path, "*.json");
            foreach (var file in files)
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();

                    if (json.Contains("pictures"))
                    {
                        int picturesplace = json.IndexOf("pictures");

                        var picturesJson = "{" + json.Substring(picturesplace);


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

                    }


                    json = json.Replace("{", "");
                    json = json.Replace("}", "");
                    json = json.Replace("[", "{");
                    json = json.Replace("]", "}");

                    var items = JsonConvert.DeserializeObject<EndoMondoTraining>(json);
                    trainings.Add(items);

                    Console.WriteLine($"{items.name} {items.sport} {items.start_time}");
                }
            }
        }
    }
}
