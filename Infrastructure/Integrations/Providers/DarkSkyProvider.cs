using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.BusinessEntities;
using Domain.Enums;
using Domain.Interfaces.Integration.Provider;
using Infrastructure.Integrations.Clients.Interfaces;
using Infrastructure.Integrations.DTOs.Request.DarkSky;

namespace Infrastructure.Integrations.Providers
{
    public class DarkSkyProvider : IWeatherProvider
    {
        private readonly IDarkSkyClient _client;

        public DarkSkyProvider(IDarkSkyClient client)
        {
            _client = client;
        }

        public WeatherProviderType ProviderType => WeatherProviderType.DarkSky;
        
        public async Task<IEnumerable<DailyWeatherBE>> GetWeatherForecasts(WeatherParamsData paramsData)
        {
            var requestModel = Mapper.Map<DarkSkyRequestModel>(paramsData);
    
            var response = await _client.GetDarkSkyWeatherResponseAsync(requestModel);
            return !response.HasError ? Mapper.Map<List<DailyWeatherBE>>(response.Response) : new List<DailyWeatherBE>();
        }
    }
}