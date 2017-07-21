using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherApp.Models
{
    [JsonObject("list")]
    public class ForecastPerDay
    {
        [JsonProperty("dt")]
        public double Time { get; set; } //time of data forecasted
        [JsonProperty("temp")]
        public Temperatures Temperatures { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("weather")]
        public List<ForecastInfo> AdditinalForecastInfo { get; set; }
        [JsonProperty("speed")]
        public double WindSpeed { get; set; } //wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        [JsonProperty("deg")]
        public double WindDirection { get; set; } //wind direction, degrees (meteorological)
        [JsonProperty("clouds")]
        public double Clouds { get; set; } //cloudiness, %
    }
}