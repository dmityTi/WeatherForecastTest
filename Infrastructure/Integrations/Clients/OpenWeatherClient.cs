using System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Integrations.Clients.Interfaces;
using Infrastructure.Integrations.DTOs.Request.OpenWeatherMap;
using Infrastructure.Integrations.DTOs.Response;
using Infrastructure.Integrations.DTOs.Response.OpenWeatherMap;

namespace Infrastructure.Integrations.Clients
{
    public class OpenWeatherClient : IOpenWeatherClient
    {
        private const string ApiKey = "77bea68862c21b7c9eb039c704002d81";
        private readonly HttpClient _httpClient;

        public OpenWeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<ResponseBase<OpenWeatherResponseModel>> GetOpenWeatherResponseAsync(OpenWeatherRequestModel model)
        {
            var responseModel = new ResponseBase<OpenWeatherResponseModel>();
            
            string queryString =
                $"forecast?appid={ApiKey}&lat={model.Latitude}&lon={model.Longitude}&units={model.Units}&lang={model.Lang}";
            
            try
            {
                var response = await _httpClient.GetAsync(queryString);
                if (response.IsSuccessStatusCode)
                    responseModel.Response =  await response.Content.ReadAsAsync<OpenWeatherResponseModel>();
            }
            catch (HttpRequestException e)
            {
                responseModel.HasError = true;
            }
            catch (Exception e)
            {
                responseModel.HasError = true;
            }

            return responseModel;
        }
    }
}