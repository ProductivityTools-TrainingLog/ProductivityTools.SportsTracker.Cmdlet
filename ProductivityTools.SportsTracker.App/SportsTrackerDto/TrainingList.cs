using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.SportsTracker.App.Dto
{

    public class Rootobject
    {
        public object error { get; set; }
        public Payload[] payload { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Metadata
    {
        public string workoutcount { get; set; }
        public string until { get; set; }
    }

    public class Payload
    {
        public int activityId { get; set; }
        public long startTime { get; set; }
        public float totalTime { get; set; }
        public float totalDistance { get; set; }
        public float totalAscent { get; set; }
        public float totalDescent { get; set; }
        public Startposition startPosition { get; set; }
        public Stopposition stopPosition { get; set; }
        public Centerposition centerPosition { get; set; }
        public float maxSpeed { get; set; }
        public int recoveryTime { get; set; }
        public int cumulativeRecoveryTime { get; set; }
        public Rankings rankings { get; set; }
        public Extension[] extensions { get; set; }
        public string[] extensionTypes { get; set; }
        public float minAltitude { get; set; }
        public float maxAltitude { get; set; }
        public bool isEdited { get; set; }
        public bool isManuallyAdded { get; set; }
        public string workoutKey { get; set; }
        public float avgSpeed { get; set; }
        public float avgPace { get; set; }
        public int commentCount { get; set; }
        public int viewCount { get; set; }
        public int timeOffsetInMinutes { get; set; }
        public Cadence cadence { get; set; }
        public int energyConsumption { get; set; }
        public Hrdata hrdata { get; set; }
        public int pictureCount { get; set; }
        public Externalblobsourceraw externalBlobSourceRaw { get; set; }
        public Headerblobsourceraw headerBlobSourceRaw { get; set; }
    }

    public class Startposition
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Stopposition
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Centerposition
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Rankings
    {
        public Totaltimeonrouteranking totalTimeOnRouteRanking { get; set; }
    }

    public class Totaltimeonrouteranking
    {
        public int originalRanking { get; set; }
        public int originalNumberOfWorkouts { get; set; }
    }

    public class Cadence
    {
        public int max { get; set; }
        public int avg { get; set; }
    }

    public class Hrdata
    {
        public int userMaxHR { get; set; }
        public int workoutMaxHR { get; set; }
        public int workoutAvgHR { get; set; }
        public int max { get; set; }
        public int avg { get; set; }
        public int hrmax { get; set; }
    }

    public class Externalblobsourceraw
    {
        public string path { get; set; }
        public int gen { get; set; }
        public string type { get; set; }
    }

    public class Headerblobsourceraw
    {
        public string path { get; set; }
        public int gen { get; set; }
        public string type { get; set; }
    }

    public class Extension
    {
        public string type { get; set; }
        public string weatherIcon { get; set; }
        public float temperature { get; set; }
        public float windSpeed { get; set; }
        public float windDirection { get; set; }
    }

}
