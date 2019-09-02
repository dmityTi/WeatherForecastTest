using System;
using Infrastructure.Extentions;
using Newtonsoft.Json;

namespace Infrastructure.Integrations.DTOs.Response.DarkSky
{
    public class HourlyDetailResponse
    {
        [JsonProperty("time")]
        public long Timestamp { get; set; }
        
        public DateTime Date => Timestamp.TimeStampToDateTime().Date;
        public DateTime DateTime => Timestamp.TimeStampToDateTime();

        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        [JsonProperty("precipIntensity")]
        public decimal PrecipIntensity { get; set; }
        
        [JsonProperty("precipProbability")]
        public decimal PrecipProbability { get; set; }
              
        [JsonProperty("precipType")]
        public string PrecipType { get; set; }
        
        [JsonProperty("temperature")]
        public decimal Temperature { get; set; }
        
        [JsonProperty("apparentTemperature")]
        public decimal ApparentTemperature { get; set; }
        
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
        
        [JsonProperty("windBearing")]
        public int WindBearing { get; set; }
        
        [JsonProperty("cloudCover")]
        public decimal CloudCover { get; set; }
        
        [JsonProperty("uvIndex")]
        public int UvIndex { get; set; }
        
        [JsonProperty("visibility")]
        public decimal Visibility { get; set; }
        
        [JsonProperty("ozone")]
        public decimal Ozone { get; set; }
    }
}