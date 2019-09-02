namespace Infrastructure.Integrations.DTOs.Request.DarkSky
{
    public class DarkSkyRequestModel
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Units { get; set; } = "us";
        public string Lang { get; set; } = "en";
    }
}