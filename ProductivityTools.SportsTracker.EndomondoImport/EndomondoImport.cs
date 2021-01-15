using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            var files = Directory.GetFiles(this.Path, "*.json");
            foreach(var file in files)
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    json = json.Replace("{", "");
                    json = json.Replace("}", "");
                    json = json.Replace("[", "{");
                    json = json.Replace("]", "}");

                    if (json.Contains("pictures"))
                    {
                        int picturesplace = json.IndexOf("pictures");
                        json = json.Substring(0, picturesplace - 1) + "}";
                        
                    }

                    if (json.Contains("tags"))
                    {
                        int picturesplace = json.IndexOf("tags");
                        json = json.Substring(0, picturesplace - 2) + "}";

                    }

                    var items = JsonConvert.DeserializeObject<Class1>(json);
                }
            }
        }
    }
}
