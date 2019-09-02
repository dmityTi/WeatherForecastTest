using System;

namespace Domain.DTOs
{
    public class DailyWeatherForecastDTO
    {
        public long CityId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        public PrecipSpanDTO PrecipSpanDto { get; set; }
    }
}