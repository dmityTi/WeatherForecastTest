using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository CityRepository { get; }
        IWeatherForecastRepository WeatherForecastRepository { get; }
        Task<int> SaveChangesAsync();
    }
}