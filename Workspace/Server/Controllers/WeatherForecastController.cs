using Microsoft.AspNetCore.Mvc;
using Workspace.Server.Data;
using Workspace.Shared;
using Workspace.Shared.Auth;

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
        private readonly AuthDbContext _authContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AuthDbContext authDbContext)
        {
            _logger = logger;
            _authContext = authDbContext;
        }

        [HttpGet]
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

        [HttpGet, Route("testAuth")]
        public async Task<List<AuthenticationClaimRequirement>> getAuth()
        {
            return await _authContext.AuthenticationClaimRequirements.ToListAsync();
        }
    }
}