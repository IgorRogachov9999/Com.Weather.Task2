using Com.Weather.Task2.Domain.Services.Dto;
using Com.Weather.Task2.Domain.Services.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Com.Weather.Task2.Api.Controllers
{
    [ApiController]
    [Route("api/v1/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryWeatherDto>>> GetAllAsync(CancellationToken ct = default)
        {
            var countryWeather = await _weatherService.GetAllAsync(ct);
            return Ok(countryWeather);
        }
    }
}
