using System.Web.Http;
using WeatherApp.Models;
using WeatherApp.Services;
using System.Net.Http;
using System.Net;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace WeatherApp.Api
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]    
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
        public async Task<HttpResponseMessage> GetCityList()
        {
            try
            {
                var cityList = await _service.GetCityListAsync();
                return Request.CreateResponse(HttpStatusCode.OK, cityList);
            }
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/Cities/AddCity/cityName
        [HttpPost]
        [Route("api/Cities/AddCity/{cityName}")]
        public async Task<HttpResponseMessage> AddCity([FromUri]string cityName)
        {
            if (cityName == null || cityName == "")
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await _service.AddCityAsync(new CityName { Name = cityName });
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Cities/DeleteCitiesWithName/cityName
        [HttpDelete]
        [Route("api/Cities/DeleteCitiesWithName/{cityName}")]
        public async Task<HttpResponseMessage> DeleteCitiesWithName([FromUri]string cityName)
        {
            if (cityName == null || cityName == "")
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await _service.DeleteCitiesWithNameAsync(cityName);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
