namespace Infrastructure.Integrations.DTOs.Request.OpenWeatherMap
{
    public class OpenWeatherRequestModel
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Units { get; set; }
        public string Lang { get; set; } 
    }
}