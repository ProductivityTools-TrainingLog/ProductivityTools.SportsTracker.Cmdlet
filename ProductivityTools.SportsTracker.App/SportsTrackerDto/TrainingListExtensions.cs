using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.SportsTracker.App.Dto
{
    public static class TrainingListExtensions
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime StartDate(this Payload that)
        {
            DateTimeOffset dateTimeOffset2 = DateTimeOffset.FromUnixTimeMilliseconds(that.startTime);

            return dateTimeOffset2.DateTime;
        }
    }
}
