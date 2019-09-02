using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.BusinessEntities;
using Domain.DTOs;
using Domain.Enums;

namespace Domain.Interfaces.Service
{
    public interface IWeatherService
    {
        Task<IEnumerable<DailyWeatherForecastDTO>> GetAverageWeatherForecastForPeriodByAllProviders(
            WeatherParamsData data);
        Task<IEnumerable<DailyWeatherForecastDTO>> GetWeatherForecastsForPeriod(WeatherParamsData data,
            WeatherProviderType providerType);
    }
}