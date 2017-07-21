using Newtonsoft.Json;

namespace WeatherApp.Models
{
    [JsonObject("weather")]
    public class ForecastInfo //more info Weather condition codes
    {
        [JsonProperty("id")]
        public int Id { get; set; } //weather condition id
        [JsonProperty("main")]
        public string Main { get; set; } //group of weather parameters (Rain, Snow, Extreme etc.)
        [JsonProperty("description")]
        public string Description { get; set; } //weather condition within the group
        [JsonProperty("icon")]
        public string Icon { get; set; } //weather icon id
    }
}