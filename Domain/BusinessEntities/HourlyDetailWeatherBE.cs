using System;
using Domain.Enums;

namespace Domain.BusinessEntities
{
    public class HourlyDetailWeatherBE
    {
        public DateTime DateTime { get; set; }
        public PrecipType PrecipType { get; set; }  = PrecipType.NoPrecipitation;
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
    }
}