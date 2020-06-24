using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using WeatherForecast.API.Data;
using WeatherForecast.API.Models;
using WeatherForecast.API.Repository.Interfaces;

namespace WeatherForecast.API.Repository
{
	public class WeatherForecastRepository : Repository, IWeatherForecastRepository
	{
		public WeatherForecastRepository(DataContext context) : base(context)
		{
		}

		public async Task<WeatherForecastModel> AddTaskAsync(WeatherForecastModel weatherForecastModel)
		{
			var addedmodel = (await _context.WeatherForecasts.AddAsync(weatherForecastModel)).Entity;
			await _context.SaveChangesAsync();
			return addedmodel;
		}

		public async Task<List<WeatherForecastModel>> FindAllTaskAsync()
		{
			return await _context.WeatherForecasts.ToListAsync();
		}
	}
}