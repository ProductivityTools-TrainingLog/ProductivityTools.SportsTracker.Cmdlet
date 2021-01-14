using System;
using System.Security.Cryptography.X509Certificates;

namespace ProductivityTools.SportsTracker.EndomondoImport
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

        }
    }
}
