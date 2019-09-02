using System;
using Domain.Enums;

namespace Domain.DTOs
{
    public class PrecipSpanDTO
    {
        public DateTime StartPrecip { get; set; }
        public DateTime EndPrecip { get; set; }
        public PrecipType PrecipType { get; set; }
    }
}