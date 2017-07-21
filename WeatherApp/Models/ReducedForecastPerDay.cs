namespace WeatherApp.Models
{
    public class ReducedForecastPerDay
    {
        public double Time { get; set; } //time of data forecasted
        public double DayTemp { get; set; } //day temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        public double NightTemp { get; set; } //night temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        public double EveningTemp { get; set; }
        public double MorningTemp { get; set; }
        public string Rain { get; set; } //weather condition within the group (Rain, Snow, Extreme etc.)
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; } //wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        public double WindDirection { get; set; } //wind direction, degrees (meteorological)
        public double Clouds { get; set; } //cloudiness, %


    }
}