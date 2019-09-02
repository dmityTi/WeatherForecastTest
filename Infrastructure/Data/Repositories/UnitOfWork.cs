using System;
using System.Threading.Tasks;
using Domain.Interfaces.Data;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeatherContext _dbContext;
        private bool _disposed;
        private ICityRepository _cityRepo;
        public IWeatherForecastRepository _weatherForecastRepo;
        public ICityRepository CityRepository => _cityRepo ?? (_cityRepo = new CityRepository(_dbContext));
        public IWeatherForecastRepository WeatherForecastRepository { get; } //*******

        public UnitOfWork(DbContextOptions<WeatherContext> options)
        {
            _dbContext = new WeatherContext(options);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}