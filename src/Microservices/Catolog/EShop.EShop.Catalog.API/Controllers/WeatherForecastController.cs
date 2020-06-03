using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EShop.Domain.Core.EventBus;
using EShop.Domain.Core.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEventBus _bus;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEventBus bus)
        {
            _logger = logger;
            _bus = bus;
        }


        private void GetPerformance(Action action, out string timeElapsed)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            timeElapsed = stopwatch.Elapsed.TotalSeconds.ToString();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetAsync()
        {
            GetPerformance(async () =>
            {
                var tasks = new List<Task>();

                for (int i = 0; i < 100000; i++)
                {
                    Event @event = new Event();

                    await _bus.PublishAsync(@event);
                }
            }, out string timeElapsed);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
