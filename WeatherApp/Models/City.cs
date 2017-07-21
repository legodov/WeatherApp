using Newtonsoft.Json;

namespace WeatherApp.Models
{
    [JsonObject("city")]
    public class City 
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("coord")]
        public Coordinates Location { get; set; }
        [JsonProperty("country")]
        public string CountryCode { get; set; } //GB, JP etc.
    }
}