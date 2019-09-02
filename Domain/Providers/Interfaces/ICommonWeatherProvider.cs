using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.BusinessEntities;
using Domain.Enums;

namespace Domain.Providers.Interfaces
{
    public interface ICommonWeatherProvider
    {
        Task<Dictionary<WeatherProviderType, IEnumerable<DailyWeatherBE>>> GetWeatherForecastsByAllProviders(WeatherParamsData model);
        Task<IEnumerable<DailyWeatherBE>> GetWeatherForecasts(WeatherProviderType providerType, WeatherParamsData model);
    }
}