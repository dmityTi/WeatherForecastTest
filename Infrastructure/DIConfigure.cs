using Domain.Interfaces.Data;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class DIConfigure
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
        }
    }
}