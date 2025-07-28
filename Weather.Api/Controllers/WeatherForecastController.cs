using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Api.Models;

namespace Weather.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WeatherForecastController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var client = _httpClientFactory.CreateClient("ProviderClient");

            var providerForecast = await client.GetFromJsonAsync<List<ProviderForecast>>("weatherforecast");

            return providerForecast.Select(x => new WeatherForecast
            {
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                TemperatureF = x.TemperatureC * 9 / 5 + 32.2,
                Summary = x.Summary
            }).ToArray();
        }
    }
}
