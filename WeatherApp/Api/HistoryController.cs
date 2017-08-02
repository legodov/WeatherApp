using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherApp.Services;

namespace WeatherApp.Api
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class HistoryController : ApiController
    {
        private IWeatherService _service;

        public HistoryController(IWeatherService service)
        {
            _service = service;
        }

        // GET: api/History/GetHistory
        [HttpGet]
        [Route("api/History/GetHistory")]
        public async Task<HttpResponseMessage> GetHistory()
        {
            try
            {
                var history = await _service.GetHistoryAsync();
                return Request.CreateResponse(HttpStatusCode.OK, history);
            }
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
