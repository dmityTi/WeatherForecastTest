using System;
using Domain.Enums;

namespace Infrastructure.Data.Entities
{
    internal class PrecipitationSpanEntity : BaseEntity
    {
        public DateTime StartPrecip { get; set; }
        public DateTime EndPrecip { get; set; }
        public PrecipType PrecipType { get; set; }
    }
}