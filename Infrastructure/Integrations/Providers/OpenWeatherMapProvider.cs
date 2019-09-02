using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.BusinessEntities;
using Domain.Enums;
using Domain.Interfaces.Integration.Provider;
using Infrastructure.Integrations.Clients.Interfaces;
using Infrastructure.Integrations.DTOs.Request.OpenWeatherMap;

namespace Infrastructure.Integrations.Providers
{
    public class OpenWeatherMapProvider : IWeatherProvider
    {
        private readonly IOpenWeatherClient _client;

        public OpenWeatherMapProvider(IOpenWeatherClient client)
        {
            _client = client;
        }
        
        public WeatherProviderType ProviderType => WeatherProviderType.OpenWeatherMap;
        public async Task<IEnumerable<DailyWeatherBE>> GetWeatherForecasts(WeatherParamsData paramsData)
        {
            var requestModel = Mapper.Map<OpenWeatherRequestModel>(paramsData);
            
            var response = await _client.GetOpenWeatherResponseAsync(requestModel);
            return !response.HasError ? Mapper.Map<List<DailyWeatherBE>>(response.Response) : new List<DailyWeatherBE>();
        }
    }
}