using BlazorApp1.Shared.WeatherForecast;
using BlazorApp1.Shared.WeatherForecast.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastDto> Get()
        {
            var logic = new WeatherForecastLogic();

            return logic.GetWeatherForecast();
        }
    }
}