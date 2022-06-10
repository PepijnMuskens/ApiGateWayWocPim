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
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        static HttpClient client = new HttpClient();
        private string baseAddress { get; set; }
        private string returnstring { get; set; }
        public ProductController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            baseAddress = "https://productservice20220610120131.azurewebsites.net";
            //baseAddress = "https://localhost:7023";
            returnstring = "";
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("GetProducts")]
        public async Task<string> Get()
        {
            return await client.GetStringAsync(baseAddress + "/Products");
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("Upload")]
        public async Task<string> Post(string json)
        {
            var response = await client.GetStringAsync(baseAddress + "/addproduct?doc=" + json);
            return "succes";
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("GetProduct")]
        public async Task<string> Getwithbrand(int id)
        {
            return await client.GetStringAsync(baseAddress + "/productsFromBrand?brand="+id);
        }
    }
}