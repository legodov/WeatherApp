using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherApp.Services;

namespace WeatherApp.Api
{
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
        public HttpResponseMessage GetHistory()
        {
            try
            {
                var history = _service.GetHistory();
                return Request.CreateResponse(HttpStatusCode.OK, history);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
