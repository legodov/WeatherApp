using WeatherApp.Models;

namespace WeatherApp.Converters
{
    public static class WeatherDataConverter
    {
        public static ReducedForecastPerDay GetReducedForecastForFirstDay(WeatherData weatherData)
        {
            return new ReducedForecastPerDay
            {
                Time = weatherData.Forecast[0].Time,
                DayTemp = weatherData.Forecast[0].Temperatures.Day,
                NightTemp = weatherData.Forecast[0].Temperatures.Night,
                EveningTemp = weatherData.Forecast[0].Temperatures.Evening,
                MorningTemp = weatherData.Forecast[0].Temperatures.Morning,
                Rain = weatherData.Forecast[0].AdditinalForecastInfo[0].Description,
                Pressure = weatherData.Forecast[0].Pressure,
                Humidity = weatherData.Forecast[0].Humidity,
                WindSpeed = weatherData.Forecast[0].WindSpeed,
                WindDirection = weatherData.Forecast[0].WindDirection,
                Clouds = weatherData.Forecast[0].Clouds
            };
        }
    }
}