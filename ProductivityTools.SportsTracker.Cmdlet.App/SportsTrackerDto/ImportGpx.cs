using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.SportsTracker.App.SportsTrackerDto.ImportGpx
{

    public class Rootobject
    {
        public object error { get; set; }
        public Payload payload { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Payload
    {
        public string username { get; set; }
        public int sharingFlags { get; set; }
        public int activityId { get; set; }
        public string key { get; set; }
        public long startTime { get; set; }
        public long stopTime { get; set; }
        public float totalTime { get; set; }
        public float totalDistance { get; set; }
        public float totalAscent { get; set; }
        public float totalDescent { get; set; }
        public Startposition startPosition { get; set; }
        public Stopposition stopPosition { get; set; }
        public Centerposition centerPosition { get; set; }
        public float maxSpeed { get; set; }
        public string polyline { get; set; }
        public bool visibilityGroups { get; set; }
        public bool visibilityExplore { get; set; }
        public bool visibilityFriends { get; set; }
        public bool visibilityFacebook { get; set; }
        public bool visibilityTwitter { get; set; }
        public int stepCount { get; set; }
        public int recoveryTime { get; set; }
        public int cumulativeRecoveryTime { get; set; }
        public Rankings rankings { get; set; }
        public float minAltitude { get; set; }
        public float maxAltitude { get; set; }
        public bool isManuallyAdded { get; set; }
        public long lastModified { get; set; }
        public int reactionCount { get; set; }
        public int energyConsumption { get; set; }
        public float avgSpeed { get; set; }
        public float avgPace { get; set; }
        public int commentCount { get; set; }
        public int viewCount { get; set; }
        public int timeInZone0 { get; set; }
        public int timeInZone1 { get; set; }
        public int timeInZone2 { get; set; }
        public int timeInZone3 { get; set; }
        public int timeInZone4 { get; set; }
        public int timeInZone5 { get; set; }
        public Cadence cadence { get; set; }
        public long created { get; set; }
        public int timeOffsetInMinutes { get; set; }
        public Hrdata hrdata { get; set; }
        public int pictureCount { get; set; }
        public string workoutKey { get; set; }
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

    public class Metadata
    {
        public string INFO { get; set; }
    }

}
