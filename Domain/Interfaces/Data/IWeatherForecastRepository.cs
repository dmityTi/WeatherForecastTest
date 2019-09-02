using Domain.DTOs;

namespace Domain.Interfaces.Data
{
    public interface IWeatherForecastRepository : IRepository<DailyWeatherForecastDTO>
    {
    }
}