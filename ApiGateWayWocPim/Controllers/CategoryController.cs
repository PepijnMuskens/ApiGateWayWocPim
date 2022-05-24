using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
namespace ApiGateWayWocPim.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        static HttpClient client = new HttpClient();
        private string baseAddress { get; set; }
        private string returnstring { get; set; }
        public CategoryController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            baseAddress = "https://wocproductservice.azurewebsites.net";
            //baseAddress = "https://localhost:7023";
            returnstring = "";
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("Getcategory")]
        public async Task<string> Get(string name)
        {
            return await client.GetStringAsync(baseAddress + "/category?name="+ name);
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("GetCategories")]
        public async Task<string> Get()
        {
            return await client.GetStringAsync(baseAddress + "/categories");
        }
    }
}