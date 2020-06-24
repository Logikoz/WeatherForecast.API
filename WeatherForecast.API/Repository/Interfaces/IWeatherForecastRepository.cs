using System.Collections.Generic;
using System.Threading.Tasks;

using WeatherForecast.API.Models;

namespace WeatherForecast.API.Repository.Interfaces
{
	public interface IWeatherForecastRepository
	{
		Task<WeatherForecastModel> AddTaskAsync(WeatherForecastModel weatherForecastModel);
		Task<List<WeatherForecastModel>> FindAllTaskAsync();
	}
}