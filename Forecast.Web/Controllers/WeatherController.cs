using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Providers;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly WeatherForecastProvider _forecastProvider;

        public WeatherController(IHostingEnvironment env, WeatherForecastProvider forecastProvider)
        {
            _env = env;
            _forecastProvider = forecastProvider;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> WeatherForecast([FromQuery] ForecastRequestData data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var models = await _forecastProvider.GetWeatherForecast(data);
            return Ok(models);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSelectOptionsData()
        {
            var model = await _forecastProvider.GetSelectOptionsData();
            return Ok(model);
        }
    }
}
