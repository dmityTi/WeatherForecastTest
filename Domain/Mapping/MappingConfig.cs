using System.Linq;
using AutoMapper.Configuration;
using Domain.BusinessEntities;
using Domain.DTOs;
using Domain.Enums;

namespace Domain.Mapping
{
    public class MappingConfig
    {
        public static void RegisterMapping(MapperConfigurationExpression config)
        {
            config.CreateMap<DailyWeatherBE, DailyWeatherForecastDTO>()
                .ForMember(d => d.PrecipSpanDto,
                    opt => opt.ResolveUsing(PrecipSpanConverter));
        }

        private static object PrecipSpanConverter(DailyWeatherBE value)
        {
            if (value.HourlyDetails.Any(x => x.PrecipType != PrecipType.NoPrecipitation))
            {
                return new PrecipSpanDTO
                {
                    PrecipType = value.PrecipType,
                    StartPrecip = value.HourlyDetails.Where(x => x.PrecipType != PrecipType.NoPrecipitation)
                        .Min(x => x.DateTime),
                    EndPrecip = value.HourlyDetails.Where(x => x.PrecipType != PrecipType.NoPrecipitation)
                        .Max(x => x.DateTime)
                };
            }

            return null;
        }
    }
}