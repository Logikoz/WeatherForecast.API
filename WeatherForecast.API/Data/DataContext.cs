using Microsoft.EntityFrameworkCore;

using WeatherForecast.API.Models;

namespace WeatherForecast.API.Data
{
	public class DataContext : DbContext
	{
		public DbSet<WeatherForecastModel> WeatherForecasts { get; set; }

		public DataContext(DbContextOptions options) : base(options)
		{
		}
	}
}