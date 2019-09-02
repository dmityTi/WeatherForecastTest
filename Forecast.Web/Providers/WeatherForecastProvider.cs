using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.BusinessEntities;
using Domain.DTOs;
using Domain.Enums;
using Domain.Interfaces.Data;
using Domain.Interfaces.Service;
using WebApplication2.Models;

namespace WebApplication2.Providers
{
    public class WeatherForecastProvider
    {
        private readonly IWeatherService _weatherService;
        private readonly IUnitOfWork _db;

        public WeatherForecastProvider(IWeatherService weatherService, IUnitOfWork db)
        {
            _weatherService = weatherService;
            _db = db;
        }

        public async Task<IEnumerable<DailyForecastViewModel>> GetWeatherForecast(ForecastRequestData data)
        {
            var paramsData = Mapper.Map<WeatherParamsData>(data);

            IEnumerable<DailyWeatherForecastDTO> result;
            if (data.ProviderType == WeatherForecastProviderType.All)
                result = await _weatherService.GetAverageWeatherForecastForPeriodByAllProviders(paramsData);
            else
                result = await _weatherService.GetWeatherForecastsForPeriod(paramsData, (WeatherProviderType)data.ProviderType);

            return Mapper.Map<IEnumerable<DailyForecastViewModel>>(result);
        }

        public async Task<SelectOptionsData> GetSelectOptionsData()
        {
            var cities = await _db.CityRepository.ListAllAsync(true);

            return new SelectOptionsData
            {
                Cities = Mapper.Map<List<CityOption>>(cities),
                Providers = Enum.GetNames(typeof(WeatherForecastProviderType)).ToList(),
                Units = Enum.GetNames(typeof(UnitsType)).ToList(),
                Languages = Enum.GetNames(typeof(LangType)).ToList()
            };
        }
    }
}
