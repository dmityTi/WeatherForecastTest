using System.Threading.Tasks;
using Infrastructure.Integrations.DTOs.Request.DarkSky;
using Infrastructure.Integrations.DTOs.Response;
using Infrastructure.Integrations.DTOs.Response.DarkSky;

namespace Infrastructure.Integrations.Clients.Interfaces
{
    public interface IDarkSkyClient
    {
        Task<ResponseBase<DarkSkyResponseModel>> GetDarkSkyWeatherResponseAsync(DarkSkyRequestModel model);
    }
}