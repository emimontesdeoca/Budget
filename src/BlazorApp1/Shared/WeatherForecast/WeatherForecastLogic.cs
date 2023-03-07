using BlazorApp1.Shared.WeatherForecast.Models;

namespace BlazorApp1.Shared.WeatherForecast
{
    public class WeatherForecastLogic
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecastDto> GetWeatherForecast()
        {
            WeatherForecastModel[] weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastModel()
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
