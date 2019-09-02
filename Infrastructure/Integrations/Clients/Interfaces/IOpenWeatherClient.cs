using System.Threading.Tasks;
using Infrastructure.Integrations.DTOs.Request.OpenWeatherMap;
using Infrastructure.Integrations.DTOs.Response;
using Infrastructure.Integrations.DTOs.Response.OpenWeatherMap;

namespace Infrastructure.Integrations.Clients.Interfaces
{
    public interface IOpenWeatherClient
    {
        Task<ResponseBase<OpenWeatherResponseModel>> GetOpenWeatherResponseAsync(OpenWeatherRequestModel model);
    }
}