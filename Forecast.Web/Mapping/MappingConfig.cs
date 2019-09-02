using AutoMapper;
using AutoMapper.Configuration;
using Domain.BusinessEntities;
using Domain.DTOs;
using WebApplication2.Controllers;
using WebApplication2.Models;

namespace WebApplication2.Mapping
{
    public class MappingConfig
    {
        public static void RegisterMapping()
        {
            var mapperConfig = new MapperConfigurationExpression();
            Init(mapperConfig);

            Infrastructure.Mapping.MappingConfig.RegisterMapping(mapperConfig);
            Domain.Mapping.MappingConfig.RegisterMapping(mapperConfig);

            Mapper.Initialize(mapperConfig);
        }

        private static void Init(MapperConfigurationExpression config)
        {
            config.CreateMap<ForecastRequestData, WeatherParamsData>()
                .ForMember(d => d.QuantityDays,
                    opt => opt.MapFrom(s => s.Days))
                .ForMember(d => d.Latitude,
                    opt => opt.MapFrom(s => s.Lat))
                .ForMember(d => d.Longitude,
                    opt => opt.MapFrom(s => s.Lon));

            config.CreateMap<DailyWeatherForecastDTO, DailyForecastViewModel>()
                .ForMember(d => d.PrecipPeriod,
                    opt => opt.MapFrom(s =>
                        s.PrecipSpanDto == null
                            ? null
                            : $"{s.PrecipSpanDto.StartPrecip} - {s.PrecipSpanDto.EndPrecip.TimeOfDay}"))
                .ForMember(d => d.Date,
                    opt => opt.MapFrom(s => s.DateTime.ToString("dddd, MMMM d, yyyy}")));

            config.CreateMap<CityDTO, CityOption>();
        }
    }
}
