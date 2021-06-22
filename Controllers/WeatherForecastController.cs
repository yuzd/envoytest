using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace envoy.Controllers
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
        private readonly IOptionsMonitor<Settings> _settings;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptionsMonitor<Settings> settings)
        {
            _logger = logger;
            _settings = settings;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            var feature = HttpContext.Features.Get<IHttpConnectionFeature>();
            string LocalIPAddr = feature?.LocalIpAddress?.ToString() ?? "unknow";

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = LocalIPAddr + ":" + (_settings.CurrentValue.Message??"null")
            })
            .ToArray();
        }
    }
}
