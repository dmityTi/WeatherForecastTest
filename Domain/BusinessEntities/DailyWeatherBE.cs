using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.BusinessEntities
{
    public class DailyWeatherBE
    {
        public WeatherProviderType ProviderType { get; set; }
        public DateTime DateTime { get; set; }
        public PrecipType PrecipType { get; set; } = PrecipType.NoPrecipitation;
        public decimal TemperatureMin { get; set; }
        public decimal TemperatureMax { get; set; }
        public decimal Temperature => (TemperatureMin + TemperatureMax) / 2;
        public decimal Pressure { get; set; }

        public List<HourlyDetailWeatherBE> HourlyDetails { get; set; }
    }
}