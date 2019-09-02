using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace WebApplication2.Models
{
//    [BindProperties(SupportsGet=true)]
    public class ForecastRequestData : IValidatableObject
    {
        [Range(1, 5)]
        public int Days { get; set; } = 5;

        [Required]
        public decimal Lat { get; set; }

        [Required]
        public decimal Lon { get; set; }

        public string Provider { get; set; } = WeatherForecastProviderType.All.ToString("D");
        public WeatherForecastProviderType? ProviderType
        {
            get
            {
                if (Enum.TryParse(Provider, true, out WeatherForecastProviderType res))
                    return res;

                return null;
            }
        }

        public string Units { get; set; } = Domain.Enums.UnitsType.Imperial.ToString("D");
        public UnitsType? UnitsType
        {
            get
            {
                if (Enum.TryParse(Units, true, out UnitsType res))
                    return res;

                return null;
            }
        }

        public string Lang { get; set; } = Domain.Enums.LangType.English.ToString("D");
        public LangType? LangType
        {
            get
            {
                if (Enum.TryParse(Lang, true, out LangType res))
                    return res;

                return null;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UnitsType == null)
                yield return new ValidationResult($"Invalid Units: {Units}");

            if (ProviderType == null)
                yield return new ValidationResult($"Invalid ProviderType: {Provider}");

            if (LangType == null)
                yield return new ValidationResult($"Invalid LangType: {Lang}");
        }
    }

    public enum WeatherForecastProviderType
    {
        OpenWeatherMap,
        DarkSky,
        All
    }
}
