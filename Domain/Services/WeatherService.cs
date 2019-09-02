using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.BusinessEntities;
using Domain.DTOs;
using Domain.Enums;
using Domain.Interfaces.Data;
using Domain.Interfaces.Service;
using Domain.Providers.Interfaces;
using Domain.Utils;

namespace Domain.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ICommonWeatherProvider _weatherProvider;
        private readonly IUnitOfWork _db;

        public WeatherService(ICommonWeatherProvider weatherProvider, IUnitOfWork db)
        {
            _weatherProvider = weatherProvider;
            _db = db;
        }
        
        public async Task<IEnumerable<DailyWeatherForecastDTO>> GetWeatherForecastsForPeriod(WeatherParamsData data, WeatherProviderType providerType)
        {
            var dailyWeather = await _weatherProvider.GetWeatherForecasts(providerType, data);
            var result = Mapper.Map<IEnumerable<DailyWeatherForecastDTO>>(dailyWeather);
            
            //optional save to db
            //_db.WeatherForecastRepository.AddRange(result);
            //await _db.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<DailyWeatherForecastDTO>> GetAverageWeatherForecastForPeriodByAllProviders(WeatherParamsData data)
        {
            var sources = new List<IEnumerable<DailyWeatherForecastDTO>>();
            
            foreach (WeatherProviderType type in Enum.GetValues(typeof(WeatherProviderType)))
            {
                var dailyWeather = await GetWeatherForecastsForPeriod(data, type);
                if (dailyWeather.Any())
                    sources.Add(dailyWeather);
            }

            return !sources.Any() ? new List<DailyWeatherForecastDTO>() : AverageForecast.GetAverageForecast(sources.ToArray());
        }
    }
}