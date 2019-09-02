using System;

namespace Infrastructure.Data.Entities
{
    internal class DailyWeatherForecastEntity : BaseEntity 
    {
        public DateTime DateTime { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        
        public long CityId { get; set; }
        public Guid PrecipitationSpanId { get; set; }
        
        public PrecipitationSpanEntity PrecipitationSpan { get; set; }
        public CityEntity City { get; set; }
    }
}