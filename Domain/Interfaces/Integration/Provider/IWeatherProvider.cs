using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.BusinessEntities;
using Domain.Enums;

namespace Domain.Interfaces.Integration.Provider
{
    public interface IWeatherProvider
    {
        WeatherProviderType ProviderType { get; }
        Task<IEnumerable<DailyWeatherBE>> GetWeatherForecasts(WeatherParamsData paramsData);
    }
}