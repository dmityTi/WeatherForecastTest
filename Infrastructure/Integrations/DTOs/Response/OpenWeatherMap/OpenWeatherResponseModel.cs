using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infrastructure.Integrations.DTOs.Response.OpenWeatherMap
{
    public class OpenWeatherResponseModel
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }
        
        [JsonProperty("message")]
        public decimal Message { get; set; }
        
        [JsonProperty("cnt")]
        public int Cnt { get; set; }
        
        [JsonProperty("list")]
        public List<HourlyDetailResponse> HourlyDetails { get; set; }

        [JsonProperty("city")]
        public CityResponse CityResponse { get; set; }
    }
}