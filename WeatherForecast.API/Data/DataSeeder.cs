using Microsoft.EntityFrameworkCore.Internal;

using System;
using System.Linq;

using WeatherForecast.API.Models;

namespace WeatherForecast.API.Data
{
	public class DataSeeder
	{
		private readonly DataContext _context;

		public DataSeeder(DataContext context)
		{
			_context = context;
		}

		public void Init()
		{
			if (!_context.WeatherForecasts.Any())
			{
				_context.WeatherForecasts.Add(new WeatherForecastModel
				{
					Date = DateTime.Now.AddHours(-100),
					Summary = "Frio",
					TemperatureC = 4
				});
				_context.WeatherForecasts.Add(new WeatherForecastModel
				{
					Date = DateTime.Now.AddHours(-10),
					Summary = "Quente",
					TemperatureC = 30
				});
				_context.WeatherForecasts.Add(new WeatherForecastModel
				{
					Date = DateTime.Now,
					Summary = "Inferno",
					TemperatureC = 40
				});
				_context.WeatherForecasts.Add(new WeatherForecastModel
				{
					Date = DateTime.Now.AddDays(3),
					Summary = "Agradavel",
					TemperatureC = 23
				});
				_context.SaveChanges();
			}
		}
	}
}