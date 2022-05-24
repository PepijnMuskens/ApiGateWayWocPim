using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
namespace ApiGateWayWocPim.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        static HttpClient client = new HttpClient();
        private string baseAddress { get; set; }
        public HomeController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            baseAddress = "https://i437675.luna.fhict.nl";
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("Home")]
        public async Task<string> Get()
        {
            return await client.GetStringAsync(baseAddress + "/home/basic");
        }
    }
}