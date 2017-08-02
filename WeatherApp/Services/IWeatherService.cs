using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(string cityName, int countDays);

        IEnumerable<CityName> GetCityList();
        Task<IEnumerable<CityName>> GetCityListAsync();
        void AddCity(CityName city);
        Task AddCityAsync(CityName city);
        void DeleteCitiesWithName(string cityName);
        Task DeleteCitiesWithNameAsync(string cityName);

        IEnumerable<HistoryWeatherDataObject> GetHistory();
        Task<IEnumerable<HistoryWeatherDataObject>> GetHistoryAsync();
        void AddHistoryObject(HistoryWeatherDataObject historyObject);
        Task AddHistoryObjectAsync(HistoryWeatherDataObject historyObject);
    }
}
