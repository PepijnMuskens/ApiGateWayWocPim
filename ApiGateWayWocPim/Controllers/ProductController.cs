using Microsoft.AspNetCore.Mvc;
using System.Threading;
namespace ApiGateWayWocPim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        static HttpClient client = new HttpClient();
        private string baseAddress { get; set; }
        private string returnstring { get; set; }
        public ProductController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            baseAddress = "https://wocproductservice.azurewebsites.net";
            returnstring = "";
        }

        [HttpGet("GetProducts")]
        public async Task<string> Get()
        {
            return await client.GetStringAsync(baseAddress + "/Products");
        }
    }
}