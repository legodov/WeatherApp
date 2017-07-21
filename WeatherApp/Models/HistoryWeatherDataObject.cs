using System;

namespace WeatherApp.Models
{
    public class HistoryWeatherDataObject : IEntity
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int CountDays { get; set; }
        public DateTime RequestTime { get; set; }
        public ReducedForecastPerDay ReducedForecastPerDay { get; set; }
    }
}