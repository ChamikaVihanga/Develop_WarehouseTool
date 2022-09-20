using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared;
using Workspace.Shared.AuthData;

namespace Workspace.Server.Controllers
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
        private readonly WorkspaceDbContext _authContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WorkspaceDbContext authDbContext)
        {
            _logger = logger;
            _authContext = authDbContext;
        }

        [HttpGet, Authorize(Policy ="VSPolicy")]
        public IEnumerable<WeatherForecast> Get()
        {
            Thread.Sleep(3000);
            
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        
    }
}