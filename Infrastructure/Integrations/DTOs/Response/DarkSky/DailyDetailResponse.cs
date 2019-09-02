using System;
using Infrastructure.Extentions;
using Newtonsoft.Json;

namespace Infrastructure.Integrations.DTOs.Response.DarkSky
{
    public class DailyDetailResponse
    {
        [JsonProperty("time")]
        public long Timestamp { get; set; }
        public DateTime DateTime => Timestamp.TimeStampToDateTime();
        
        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        [JsonProperty("sunriseTime")]
        public long SunriseTime { get; set; }
        
        [JsonProperty("sunsetTime")]
        public long SunsetTime { get; set; }
        
        [JsonProperty("moonPhase")]
        public decimal MoonPhase { get; set; }
        
        [JsonProperty("precipIntensity")]
        public decimal PrecipIntensity { get; set; }
        
        [JsonProperty("precipIntensityMax")]
        public decimal PrecipIntensityMax { get; set; }
        
        [JsonProperty("precipIntensityMaxTime")]
        public long PrecipIntensityMaxTime { get; set; }
        
        [JsonProperty("precipProbability")]
        public decimal PrecipProbability { get; set; }
              
        [JsonProperty("precipType")]
        public string PrecipType { get; set; }
        
        [JsonProperty("temperatureHigh")]
        public decimal TemperatureHigh { get; set; }
        
        [JsonProperty("temperatureHighTime")]
        public long TemperatureHighTime { get; set; }
        
        [JsonProperty("temperatureLow")]
        public decimal TemperatureLow { get; set; }
        
        [JsonProperty("temperatureLowTime")]
        public long TemperatureLowTime { get; set; }
        
        [JsonProperty("apparentTemperatureHigh")]
        public decimal ApparentTemperatureHigh { get; set; }
        
        [JsonProperty("apparentTemperatureHighTime")]
        public long ApparentTemperatureHighTime { get; set; }
        
        [JsonProperty("apparentTemperatureLow")]
        public decimal ApparentTemperatureLow { get; set; }
        
        [JsonProperty("apparentTemperatureLowTime")]
        public long ApparentTemperatureLowTime { get; set; }

        [JsonProperty("dewPoint")]
        public decimal DewPoint { get; set; }
        
        [JsonProperty("humidity")]
        public decimal Humidity { get; set; }
        
        [JsonProperty("pressure")]
        public decimal Pressure { get; set; }
        
        [JsonProperty("windSpeed")]
        public decimal WindSpeed { get; set; }
        
        [JsonProperty("windGust")]
        public decimal WindGust { get; set; }
        
        [JsonProperty("windGustTime")]
        public long WindGustTime { get; set; }
        
        [JsonProperty("windBearing")]
        public int WindBearing { get; set; }
        
        [JsonProperty("cloudCover")]
        public decimal CloudCover { get; set; }

        [JsonProperty("uvIndex")]
        public int UvIndex { get; set; }
        
        [JsonProperty("uvIndexTime")]
        public long UvIndexTime { get; set; }
        
        [JsonProperty("visibility")]
        public decimal Visibility { get; set; }
        
        [JsonProperty("ozone")]
        public decimal Ozone { get; set; }
            
        [JsonProperty("temperatureMin")]
        public decimal TemperatureMin { get; set; }

        [JsonProperty("temperatureMinTime")]
        public long TemperatureMinTime { get; set; }
        
        [JsonProperty("temperatureMax")]
        public decimal TemperatureMax { get; set; }

        [JsonProperty("temperatureMaxTime")]
        public long TemperatureMaxTime { get; set; }
        
        [JsonProperty("apparentTemperatureMin")]
        public decimal ApparentTemperatureMin { get; set; }

        [JsonProperty("apparentTemperatureMinTime")]
        public long ApparentTemperatureMinTime { get; set; }
        
        [JsonProperty("apparentTemperatureMax")]
        public decimal ApparentTemperatureMax { get; set; }

        [JsonProperty("apparentTemperatureMaxTime")]
        public long ApparentTemperatureMaxTime { get; set; }
    }
}