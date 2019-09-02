using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infrastructure.Integrations.DTOs.Response.DarkSky
{
    public class DailyDetailsResponse
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        [JsonProperty("data")]
        public List<DailyDetailResponse> DailyDetails { get; set; }
    }
}