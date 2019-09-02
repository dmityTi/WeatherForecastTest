using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Integrations.Clients.Interfaces;
using Infrastructure.Integrations.DTOs.Request.DarkSky;
using Infrastructure.Integrations.DTOs.Response;
using Infrastructure.Integrations.DTOs.Response.DarkSky;

namespace Infrastructure.Integrations.Clients
{
    public class DarkSkyClient : IDarkSkyClient
    {
        private const string ApiKey = "afb07fd1640071767e85dd1c42de6cc8";
        private readonly HttpClient _httpClient;

        public DarkSkyClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<ResponseBase<DarkSkyResponseModel>> GetDarkSkyWeatherResponseAsync(DarkSkyRequestModel model)
        {
            var responseModel = new ResponseBase<DarkSkyResponseModel>();
            
            string queryString =
                $"forecast/{ApiKey}/{model.Latitude.ToString(CultureInfo.InvariantCulture)}," +
                $"{model.Longitude.ToString(CultureInfo.InvariantCulture)}" +
                $"?lang={model.Lang}&units={model.Units}&exclude=currently,minutely,alerts,flags";
           
            try
            {
                var response = await _httpClient.GetAsync(queryString);
                if (response.IsSuccessStatusCode)
                    responseModel.Response =  await response.Content.ReadAsAsync<DarkSkyResponseModel>();
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