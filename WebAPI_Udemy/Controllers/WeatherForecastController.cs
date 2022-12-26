using Microsoft.AspNetCore.Mvc;
using WebAPI_Udemy.Servicios;

namespace WebAPI_Udemy.Controllers
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
        private readonly IServicioEjemplo _servicio;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IServicioEjemplo servicio)
        {
            _logger = logger;
            _servicio = servicio;

        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }



        [HttpGet("Inyeccion")]
        public string ejemplo()
        {
            return _servicio.Ejemplo();
        }
    }
}