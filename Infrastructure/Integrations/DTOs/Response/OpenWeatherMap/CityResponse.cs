using Newtonsoft.Json;

namespace Infrastructure.Integrations.DTOs.Response.OpenWeatherMap
{
    public class CityResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("coord")]
        public CoordinateResponse CoordinateResponse { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("population")]
        public long Population { get; set; }
        
        [JsonProperty("timezone")]
        public int Timezone { get; set; }
        
        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }
        
        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }
}