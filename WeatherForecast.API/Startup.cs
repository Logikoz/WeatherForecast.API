using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WeatherForecast.API.Data;
using WeatherForecast.API.Repository;
using WeatherForecast.API.Repository.Interfaces;

namespace WeatherForecast.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddDbContext<DataContext>(
				x => x.UseSqlite("Data Source=Storage.db",
				b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

			services.AddScoped<DataSeeder>();

			services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataSeeder seeder)
		{
			using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				DataContext context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
				context.Database.Migrate();
			}

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				seeder.Init();
			}

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}