using Domain.DTOs;
using Domain.Interfaces.Data;
using Infrastructure.Data.Context;
using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Repositories
{
    internal class WeatherForecastRepository : BaseRepository<DailyWeatherForecastDTO, DailyWeatherForecastEntity>, IWeatherForecastRepository 
    {
        public WeatherForecastRepository(WeatherContext dbContext) : base(dbContext)
        {
        }
    }
}