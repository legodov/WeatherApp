using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherApp.Models;
using System.Configuration;
using WeatherApp.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private static HttpClient _client;
        private static string _apiKey;
        private static int _minCountDays;
        private static int _maxCountDays;

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        static WeatherService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            _apiKey = ConfigurationManager.AppSettings["apiKey"];

            _minCountDays = 1;
            _maxCountDays = 17;
        }
        public WeatherService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public int MinCountDays
        {
            get { return _minCountDays; }
        }
        public int MaxCountDays
        {
            get { return _maxCountDays; }
        }
        public async Task<WeatherData> GetWeatherAsync(string cityName, int countDays)
        {
            if (countDays < _minCountDays || countDays > _maxCountDays)
                throw new WeatherException(WeatherError.IncorrectCountDays, "Incorrect count days");
            string url = GetUrl(cityName, countDays, _apiKey);
            using (HttpResponseMessage response = await _client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string forecastJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherData>(forecastJson);
                }
                else throw new WeatherException(WeatherError.WeatherNotFound, "Weather not found");
            }
        }
        private string GetUrl(string cityName, int countDays, string apiKey)
        {
            string apiUrl = string.Format(ConfigurationManager.AppSettings["apiUrl"]
                + "q={0}&units=metric&cnt={1}&APPID={2}", cityName, countDays, apiKey);
            return apiUrl;
        }

        public IEnumerable<CityName> GetCityList()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return unitOfWork.Repository<CityName>().All();
            }
        }
        public void AddCity(CityName city)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.Repository<CityName>().Add(city);
                unitOfWork.SaveChanges();
            }
        }
        public void DeleteCitiesWithName(string cityName)
        {
            if (cityName == null) throw new ArgumentNullException();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var cityRepository = unitOfWork.Repository<CityName>();
                var cities = cityRepository.Query().Where(c => c.Name == cityName).ToList();
                foreach (var city in cities)
                    cityRepository.Delete(city);
                unitOfWork.SaveChanges();
            }
        }

        public IEnumerable<HistoryWeatherDataObject> GetHistory()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return unitOfWork.Repository<HistoryWeatherDataObject>().All();
            }
        }
        public void AddHistoryObject(HistoryWeatherDataObject historyObject)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.Repository<HistoryWeatherDataObject>().Add(historyObject);
                unitOfWork.SaveChanges();
            }
        }
    }
}