using System.Web.Http;
using WeatherApp.Models;
using WeatherApp.Services;
using System;
using System.Net.Http;
using System.Net;

namespace WeatherApp.Api
{
    public class CitiesController : ApiController
    {
        private IWeatherService _service;

        public CitiesController(IWeatherService service)
        {
            _service = service;
        }

        // GET: api/Cities/GetCityList
        [HttpGet]
        [Route("api/Cities/GetCityList")]
        public HttpResponseMessage GetCityList()
        {
            try
            {
                var cityList = _service.GetCityList();
                return Request.CreateResponse(HttpStatusCode.OK, cityList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST: api/Cities/AddCity/cityName
        [HttpPost]
        [Route("api/Cities/AddCity/{cityName}")]
        public HttpResponseMessage AddCity([FromUri]string cityName)
        {
            if (cityName == null || cityName == "")
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                _service.AddCity(new CityName { Name = cityName });
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Cities/DeleteCitiesWithName/cityName
        [HttpDelete]
        [Route("api/Cities/DeleteCitiesWithName/{cityName}")]
        public HttpResponseMessage DeleteCitiesWithName([FromUri]string cityName)
        {
            if (cityName == null || cityName == "")
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                _service.DeleteCitiesWithName(cityName);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
