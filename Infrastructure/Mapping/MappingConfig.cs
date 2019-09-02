using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using Domain.BusinessEntities;
using Domain.DTOs;
using Domain.Enums;
using Infrastructure.Data.Entities;
using Infrastructure.Integrations.DTOs.Request.DarkSky;
using Infrastructure.Integrations.DTOs.Request.OpenWeatherMap;
using Infrastructure.Integrations.DTOs.Response.DarkSky;
using Infrastructure.Integrations.DTOs.Response.OpenWeatherMap;

namespace Infrastructure.Mapping
{
    public class MappingConfig
    {
        public static void RegisterMapping(MapperConfigurationExpression config)
        {
            InitDarkSkyMapping(config);
            OpenWeatherMapMapping(config);

            config.CreateMap<DailyWeatherForecastDTO, DailyWeatherForecastEntity>()
                .ForMember(d => d.PrecipitationSpan,
                    o => o.MapFrom(s => s.PrecipSpanDto));

            config.CreateMap<PrecipSpanDTO, PrecipitationSpanEntity>();
        }

        #region DarkSkyMapping
        private static void InitDarkSkyMapping(MapperConfigurationExpression config)
        {
            config.CreateMap<DailyDetailResponse, DailyWeatherBE>()
                .ForMember(d => d.ProviderType,
                    o => o.MapFrom(s => WeatherProviderType.DarkSky))
                .ForMember(d => d.PrecipType,
                    opt => opt.MapFrom(s => s.PrecipType == null 
                        ? PrecipType.NoPrecipitation 
                        : Enum.Parse(typeof(PrecipType), s.PrecipType, true)));
            
            config.CreateMap<Infrastructure.Integrations.DTOs.Response.DarkSky.HourlyDetailResponse, HourlyDetailWeatherBE>()
                .ForMember(d => d.PrecipType,
                    opt => opt.MapFrom(s => s.PrecipType == null 
                        ? PrecipType.NoPrecipitation 
                        : Enum.Parse(typeof(PrecipType), s.PrecipType, true)));
            
            config.CreateMap<DarkSkyResponseModel, List<DailyWeatherBE>>()
                .ConstructUsing(DarkSkyResponseModelToListWeatherDTO);

            config.CreateMap<WeatherParamsData, DarkSkyRequestModel>()
                .ForMember(d => d.Units,
                    opt => opt.ResolveUsing(DarkSkyUnitsTypeConverter))
                .ForMember(d => d.Lang,
                    opt => opt.ResolveUsing(DarkSkyLangTypeConverter));
        }

        private static object DarkSkyUnitsTypeConverter(WeatherParamsData value)
        {
            switch (value.UnitsType)
            {
                case UnitsType.Metric:
                    return "si";
                default:
                    return "us";
            }
        }

        private static object DarkSkyLangTypeConverter(WeatherParamsData value)
        {
            switch (value.LangType)
            {
                case LangType.Russian:
                    return "ru";
                case LangType.Ukrainian:
                    return "uk";
                default:
                    return "en";
            }
        }

        private static List<DailyWeatherBE> DarkSkyResponseModelToListWeatherDTO(DarkSkyResponseModel source, ResolutionContext context)
        {
            var result = new List<DailyWeatherBE>();

            foreach (var dailyDetail in source.DailyDetailsResponse.DailyDetails)
            {
                var dailyWeatherDTO = context.Mapper.Map<DailyWeatherBE>(dailyDetail);
               
                var hourlyDetails = source.HourlyDetailsResponse.HourlyDetails.Where(x =>
                    x.Date == dailyWeatherDTO.DateTime.Date);
                
                dailyWeatherDTO.HourlyDetails = context.Mapper.Map<List<HourlyDetailWeatherBE>>(hourlyDetails);
                result.Add(dailyWeatherDTO);
            }

            return result;
        }
        #endregion

        #region OpenWeatherMapMapping

        private static void OpenWeatherMapMapping(MapperConfigurationExpression config)
        {
            config.CreateMap<Infrastructure.Integrations.DTOs.Response.OpenWeatherMap.HourlyDetailResponse, HourlyDetailWeatherBE>()
                .ForMember(d => d.PrecipType,
                    opt => opt.MapFrom(
                        s =>
                            s.Weather.Any(x =>
                                Enumerable.Range(500, 31).Contains(x.Id)) //500 to 531 - rain codes from api
                                ? PrecipType.Rain
                                : PrecipType.NoPrecipitation)
                )
                .ForMember(d => d.Temperature,
                    o => o.MapFrom(s => s.MainInfoResponse.Temp))
                .ForMember(d => d.Pressure,
                    o => o.MapFrom(s => s.MainInfoResponse.Pressure));
            
            config.CreateMap<OpenWeatherResponseModel, List<DailyWeatherBE>>()
                .ConstructUsing(OpenWeatherResponseModelToListWeatherDTO);
            
            config.CreateMap<WeatherParamsData, OpenWeatherRequestModel>()
                .ForMember(d => d.Units,
                    opt => opt.ResolveUsing(OpenWeatherMapUnitsTypeConverter))
                .ForMember(d => d.Lang,
                    opt => opt.ResolveUsing(OpenWeatherMapLangTypeConverter));
        }
        
        private static object OpenWeatherMapUnitsTypeConverter(WeatherParamsData value)
        {
            switch (value.UnitsType)
            {
                case UnitsType.Metric:
                    return "metric";
                default:
                    return "imperial";
            }
        }

        private static object OpenWeatherMapLangTypeConverter(WeatherParamsData value)
        {
            switch (value.LangType)
            {
                case LangType.Russian:
                    return "ru";
                case LangType.Ukrainian:
                    return "ua";
                default:
                    return "en";
            }
        }

        private static List<DailyWeatherBE> OpenWeatherResponseModelToListWeatherDTO(OpenWeatherResponseModel responseModel,
            ResolutionContext context)
        {
            var result = new List<DailyWeatherBE>();

            var hourlyDetailsByDay = responseModel.HourlyDetails.GroupBy(x => x.DateTime.Date);
            foreach (var detailByDay in hourlyDetailsByDay)
            {
                var hourlyDetails =  detailByDay.ToList();
                
                var dailyWeatherDTO = new DailyWeatherBE
                {
                    ProviderType = WeatherProviderType.OpenWeatherMap,
                    DateTime = detailByDay.Key,
                    HourlyDetails = context.Mapper.Map<List<HourlyDetailWeatherBE>>(hourlyDetails),
                    TemperatureMin = hourlyDetails.Min(x => x.MainInfoResponse.TempMin),
                    TemperatureMax = hourlyDetails.Min(x => x.MainInfoResponse.TempMax),
                    Pressure = hourlyDetails.Average(x => x.MainInfoResponse.Pressure)
                };
                dailyWeatherDTO.PrecipType = dailyWeatherDTO.HourlyDetails.Any(x => x.PrecipType == PrecipType.Rain)
                    ? PrecipType.Rain
                    : PrecipType.NoPrecipitation;

                result.Add(dailyWeatherDTO);
            }
            
            return result;
        }
        #endregion
    }
}