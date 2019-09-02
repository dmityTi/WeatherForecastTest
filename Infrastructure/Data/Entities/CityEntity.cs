using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities
{
    internal class CityEntity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}