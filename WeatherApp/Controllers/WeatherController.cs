using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Converters;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherService service;

        public WeatherController(IWeatherService service)
        {
            this.service = service;
        }

        // GET: Weather/Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.CityList = await service.GetCityListAsync();
                ViewBag.Error = "";
            }
            catch (Exception ex)
            {
                ViewBag.CityList = new List<CityName>();
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        // POST: Weather/Index/cityName/countDays
        [HttpPost]
        public async Task<ActionResult> Index(string cityName, int countDays)
        {
            try
            {
                WeatherData weatherData = await service.GetWeatherAsync(cityName, countDays);
                await service.AddHistoryObjectAsync(new HistoryWeatherDataObject
                {
                    City = cityName,
                    CountDays = countDays,
                    RequestTime = DateTime.Now,
                    ReducedForecastPerDay = WeatherDataConverter.GetReducedForecastForFirstDay(weatherData)
                });
                ViewBag.CityList = await service.GetCityListAsync();
                ViewBag.Error = "";
                return View(weatherData);
            }
            catch (Exception ex)
            {
                ViewBag.CityList = new List<CityName>();
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Weather/History
        [HttpGet]
        public async Task<ActionResult> History()
        {
            try
            {
                ViewBag.History = await service.GetHistoryAsync();
                ViewBag.Error = "";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        // GET: Weather/Configurations
        [HttpGet]
        public async Task<ActionResult> Configurations()
        {
            try
            {
                ViewBag.CityList = await service.GetCityListAsync();
                ViewBag.Error = "";
            }
            catch (Exception ex)
            {
                ViewBag.CityList = new List<CityName>();
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        // POST: Weather/Configurations
        [HttpPost]
        public async Task<ActionResult> Configurations(string configAction, string cityName)
        {
            try
            {
                if (configAction == "Add")
                    await service.AddCityAsync(new CityName { Name = cityName });
                else if (configAction == "Delete")
                    await service.DeleteCitiesWithNameAsync(cityName);
                ViewBag.CityList = await service.GetCityListAsync();
                ViewBag.Error = "";
            }
            catch (Exception ex)
            {
                ViewBag.CityList = new List<CityName>();
                ViewBag.Error = ex.Message;
            }
            return View();

        }
    }
}