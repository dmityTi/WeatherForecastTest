namespace Domain.DTOs
{
    public class CityDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}