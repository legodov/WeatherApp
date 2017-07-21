using Newtonsoft.Json;

namespace WeatherApp.Models
{
    [JsonObject("temp")]
    public class Temperatures //temperatures per day
    {
        [JsonProperty("day")]
        public double Day { get; set; } //day temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        [JsonProperty("min")]
        public double Min { get; set; } // min daily temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        [JsonProperty("max")]
        public double Max { get; set; }
        [JsonProperty("night")]
        public double Night { get; set; } //night temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        [JsonProperty("eve")]
        public double Evening { get; set; }
        [JsonProperty("morn")]
        public double Morning { get; set; }
    }
}