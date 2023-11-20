using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TARpe22ShopLemming.Core.Dto.WeatherDto
{
    public class DailyForecastDto
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }

    }
    public class Temperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }
    public class Day
    {
        [JsonPropertyName("Icon")]
        public int Icon { get; set; }
        [JsonPropertyName("IconPhrase")]
        public string IconPhrase { get; set; }
        [JsonPropertyName("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }
        [JsonPropertyName("PrecipitationType")]
        public string PrecipitationType { get; set; }
        [JsonPropertyName("PrecipitationIntensity")]
        public string PrecipitationIntensity { get; set; }
    }
    public class Night
    {
        [JsonPropertyName("Icon")]
        public int Icon { get; set; }
        [JsonPropertyName("IconPhrase")]
        public string IconPhrase { get; set; }
        [JsonPropertyName("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }
        [JsonPropertyName("PrecipitationType")]
        public string PrecipitationType { get; set; }
        [JsonPropertyName("PrecipitationIntensity")]
        public string PrecipitationIntensity { get; set; }
    }
    public class Maximum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
    public class Minimum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
}
