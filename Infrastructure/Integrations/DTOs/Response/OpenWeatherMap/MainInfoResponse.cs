using Newtonsoft.Json;

namespace Infrastructure.Integrations.DTOs.Response.OpenWeatherMap
{
    public class MainInfoResponse
    {
        [JsonProperty("temp")]
        public decimal Temp { get; set; }
        
        [JsonProperty("temp_min")]
        public decimal TempMin { get; set; }
        
        [JsonProperty("temp_max")]
        public decimal TempMax { get; set; }
        
        [JsonProperty("pressure")]
        public decimal Pressure { get; set; }
        
        [JsonProperty("sea_level")]
        public decimal SeaLevel { get; set; }
        
        [JsonProperty("grnd_level")]
        public decimal GrndLevel { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public decimal TempKf { get; set; }
    }
}