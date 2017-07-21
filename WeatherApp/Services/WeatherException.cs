using System;

namespace WeatherApp.Services
{
    public class WeatherException : Exception
    {
        public readonly WeatherError Error;

        public WeatherException(WeatherError error, string message = null) : base(message)
        {
            Error = error;
        }
    }
}