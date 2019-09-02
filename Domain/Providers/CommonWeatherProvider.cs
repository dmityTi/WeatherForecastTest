using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BusinessEntities;
using Domain.Enums;
using Domain.Interfaces.Integration.Provider;
using Domain.Providers.Interfaces;

namespace Domain.Providers
{
    public class CommonWeatherProvider : ICommonWeatherProvider
    {
        private readonly IEnumerable<IWeatherProvider> _providers;

        public CommonWeatherProvider(IEnumerable<IWeatherProvider> providers)
        {
            _providers = providers;
        }
        
        public async Task<Dictionary<WeatherProviderType, IEnumerable<DailyWeatherBE>>> GetWeatherForecastsByAllProviders(WeatherParamsData model)
        {
            var result = new Dictionary<WeatherProviderType, IEnumerable<DailyWeatherBE>>();
            
            foreach (var provider in _providers)
            {
                var forecasts = await provider.GetWeatherForecasts(model);
                if (forecasts.Any())
                    result.Add(provider.ProviderType, forecasts);
            }

            return result;
        }

        public async Task<IEnumerable<DailyWeatherBE>> GetWeatherForecasts(WeatherProviderType providerType, WeatherParamsData model)
        {
            IWeatherProvider provider = _providers.FirstOrDefault(x => x.ProviderType == providerType);
            if(provider == null)
                throw new NotSupportedException(nameof(providerType));
            
            return await provider.GetWeatherForecasts(model);
        }
    }
}