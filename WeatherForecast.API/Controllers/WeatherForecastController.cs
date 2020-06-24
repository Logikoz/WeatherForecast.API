using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using WeatherForecast.API.Models;
using WeatherForecast.API.Repository.Interfaces;

namespace WeatherForecast.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IWeatherForecastRepository _forecastRepository;

		public WeatherForecastController(IWeatherForecastRepository forecastRepository)
		{
			_forecastRepository = forecastRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetTaskAsync()
		{
			return Ok(await _forecastRepository.FindAllTaskAsync());
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddTaskAsync([FromBody] WeatherForecastModel weatherForecastModel)
		{
			return Created("", await _forecastRepository.AddTaskAsync(weatherForecastModel));
		}
	}
}