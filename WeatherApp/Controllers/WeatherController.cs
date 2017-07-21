using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Converters;

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
        public ActionResult Index()
        {
            try
            {
                ViewBag.CityList = service.GetCityList();
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
                service.AddHistoryObject(new HistoryWeatherDataObject
                {
                    City = cityName,
                    CountDays = countDays,
                    RequestTime = DateTime.Now,
                    ReducedForecastPerDay = WeatherDataConverter.GetReducedForecastForFirstDay(weatherData)
                });
                ViewBag.CityList = service.GetCityList();
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
        public ActionResult History()
        {
            try
            {
                ViewBag.History = service.GetHistory();
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
        public ActionResult Configurations()
        {
            try
            {
                ViewBag.CityList = service.GetCityList();
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
        public ActionResult Configurations(string configAction, string cityName)
        {
            try
            {
                if (configAction == "Add")
                    service.AddCity(new CityName { Name = cityName });
                else if (configAction == "Delete")
                    service.DeleteCitiesWithName(cityName);
                ViewBag.CityList = service.GetCityList();
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