using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.SportsTracker.Endomondo
{


    public class Rootobject
    {
        public List<Class1> Property1 { get; set; }
    }

    public class Class1
    {
        public string name { get; set; }
        public string sport { get; set; }
        public string source { get; set; }
        public string created_date { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public float duration_s { get; set; }
        public float distance_km { get; set; }
        public float calories_kcal { get; set; }
        public float speed_avg_kmh { get; set; }
    }


}
