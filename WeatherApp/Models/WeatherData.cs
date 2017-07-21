using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherApp.Models
{
    [JsonObject("RootObject")]
    public class WeatherData
    {
        [JsonProperty("Cod")]
        public string Cod { get; set; } //internal parameter
        [JsonProperty("message")]
        public double Message { get; set; } //internal parameter
        [JsonProperty("city")]
        public City City { get; set; }
        [JsonProperty("cnt")]
        public int Cnt { get; set; } //number of lines returned by this API call
        [JsonProperty("list")]
        public List<ForecastPerDay> Forecast { get; set; }
    }
}