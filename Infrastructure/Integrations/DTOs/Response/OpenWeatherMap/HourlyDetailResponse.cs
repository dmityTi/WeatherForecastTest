using System;
using System.Collections.Generic;
using Infrastructure.Extentions;
using Newtonsoft.Json;

namespace Infrastructure.Integrations.DTOs.Response.OpenWeatherMap
{
    public class HourlyDetailResponse
    {
        [JsonProperty("dt")]
        public long Timestamp  { get; set; }
        public DateTime DateTime => Timestamp.TimeStampToDateTime();
        
        [JsonProperty("main")]
        public MainInfoResponse MainInfoResponse { get; set; }
        
        [JsonProperty("weather")]
        public List<WeatherResponse> Weather { get; set; }
        
        [JsonProperty("clouds")]
        public CloudsResponse CloudsResponse { get; set; }
        
        [JsonProperty("wind")]
        public WindResponse WindResponse { get; set; }
        
        [JsonProperty("sys")]
        public SysResponse SysResponse { get; set; }
        
        [JsonProperty("dt_txt")]
        public string DateText { get; set; }
    }
    
    public class WeatherResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("main")]
        public string Main { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public struct CloudsResponse
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }

    public struct WindResponse
    {
        [JsonProperty("speed")]
        public decimal Speed { get; set; }
        
        [JsonProperty("deg")]
        public decimal Deg { get; set; }
    }

    public class SysResponse
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}