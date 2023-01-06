using BlazorApp1.Server.Models;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastDto> Get()
        {
            WeatherForecast[] weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast()
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

             var dtos = new List<WeatherForecastDto>();
             foreach (var forecast in weatherForecasts)
             {
                 dtos.Add(new WeatherForecastDto()
                 {
                     Date = forecast.Date,
                     Summary = forecast.Summary,
                     TemperatureC = forecast.TemperatureC
                 });
             }

             return dtos;
        }
    }
}