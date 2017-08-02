using System;

namespace WeatherApp.Converters
{
    public static class TimeConverter
    {
        public static DateTime ConvertFromEpochToHuman(double epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        }
        public static double GetCurrentEpochTime()
        {
            return (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}