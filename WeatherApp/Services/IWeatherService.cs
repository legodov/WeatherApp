using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(string cityName, int countDays);

        IEnumerable<CityName> GetCityList();
        void AddCity(CityName city);
        void DeleteCitiesWithName(string cityName);

        IEnumerable<HistoryWeatherDataObject> GetHistory();
        void AddHistoryObject(HistoryWeatherDataObject historyObject);
    }
}
