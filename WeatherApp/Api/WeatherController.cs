using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherApp.Services;

namespace WeatherApp.Api
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        private IWeatherService _service;

        public WeatherController(IWeatherService service)
        {
            _service = service;
        }

        // GET: api/Weather/GetWeather/cityName/countDays
        [HttpGet]
        [Route("api/Weather/GetWeather/{cityName}/{countDays}")]
        public async Task<HttpResponseMessage> GetWeather(string cityName, int countDays = 7)
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
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
