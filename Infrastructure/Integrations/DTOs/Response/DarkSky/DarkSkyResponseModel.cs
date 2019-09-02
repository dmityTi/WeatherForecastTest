using Newtonsoft.Json;

namespace Infrastructure.Integrations.DTOs.Response.DarkSky
{
    public class DarkSkyResponseModel
    {
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }
        
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }
        
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        
        [JsonProperty("hourly")]
        public HourlyDetailsResponse HourlyDetailsResponse { get; set; }

        [JsonProperty("daily")]
        public DailyDetailsResponse DailyDetailsResponse { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}