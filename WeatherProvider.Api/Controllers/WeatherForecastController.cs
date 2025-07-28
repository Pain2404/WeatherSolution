using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherProvider.Api.Models;

namespace WeatherProvider.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing","Bracing","Chilly","Cool","Mild"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.UtcNow.AddDays(index).ToString("yyyyMMdd"),
                TemperatureC = Random.Shared.Next(-20,35),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                
            }).ToArray();
        }
    }
}
