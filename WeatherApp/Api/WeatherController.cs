using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherApp.Services;

namespace WeatherApp.Api
{
    public class WeatherController : ApiController
    {
        private IWeatherService _service;

        public WeatherController(IWeatherService service)
        {
            _service = service;
        }

        // GET: api/Weather/GetWeatherAsync/cityName/countDays
        [HttpGet]
        [Route("api/Weather/GetWeatherAsync/{cityName}/{countDays}")]
        public async Task<HttpResponseMessage> GetWeatherAsync(string cityName, int countDays = 7)
        {
            try
            {
                var weatherData = await _service.GetWeatherAsync(cityName, countDays);
                return Request.CreateResponse(HttpStatusCode.OK, weatherData);
            }
            catch (WeatherException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
