using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DTOs;

namespace Domain.Utils
{
    public static class AverageForecast
    {
        private static IEnumerable<DailyWeatherForecastDTO> GetAverageForecastForTwoSources(IEnumerable<DailyWeatherForecastDTO> source1,
            IEnumerable<DailyWeatherForecastDTO> source2)
        {
            var result = source1.Zip(source2,
                (forecast1, forecast2) => new DailyWeatherForecastDTO
                {
                    DateTime = forecast1.DateTime,
                    Temperature = (forecast1.Temperature + forecast2.Temperature) / 2,
                    Pressure = (forecast1.Pressure + forecast2.Pressure) / 2,
                    PrecipSpanDto = forecast1.PrecipSpanDto ?? forecast2.PrecipSpanDto
                });
            return result;
        }

        public static IEnumerable<DailyWeatherForecastDTO> GetAverageForecast(IEnumerable<DailyWeatherForecastDTO>[] sources)
        {
            if (sources == null || !sources.Any())
                throw new ArgumentException(nameof(sources));
            
            switch (sources.Length)
            {
                case 1:
                    return sources.First();
                case 2:
                    return GetAverageForecastForTwoSources(sources[0], sources[1]);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}