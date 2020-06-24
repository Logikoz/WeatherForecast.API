using WeatherForecast.API.Data;

namespace WeatherForecast.API.Repository
{
	public class Repository
	{
		protected readonly DataContext _context;

		protected Repository(DataContext context) => _context = context;
	}
}