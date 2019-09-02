using Newtonsoft.Json;

namespace Infrastructure.Integrations.DTOs.Response.OpenWeatherMap
{
    public struct CoordinateResponse
    {
        [JsonProperty("lat")]
        public decimal Latitude { get; set; }
        
        [JsonProperty("lon")]
        public decimal Longitude { get; set; }
    }
}