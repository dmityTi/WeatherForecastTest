using Domain.Enums;

namespace Domain.BusinessEntities
{
    public class WeatherParamsData
    {
        public int QuantityDays { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public UnitsType UnitsType { get; set; }
        public LangType LangType { get; set; }
    }
}