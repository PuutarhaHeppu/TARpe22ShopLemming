using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe22ShopLemming.Core.Dto.WeatherDto
{
    public class WeatherResultDto
    {
        public bool DayHasPrecipitation;
        public int EffectiveEpochDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime EndDate { get; set; }
        public int EndEpochDate { get; set; }

        public DateTime DailyForecasts { get; set; }
        public string DailyForecastsEpochDate { get; set; } 
        
        public string MobileLink { get; set; }
        public string Link { get; set; }

        public double TempMinValue { get; set; }
        public string TempMinUnit { get; set; }
        public int TempMinUnitType { get; set; }

        public double TempMaxValue { get; set; }
        public string TempMaxUnit { get; set; }
        public int TempMaxUnitType { get; set; }

        public int DayIcon { get; set; }
        public bool DayHasPercipitation { get; set; }
        public string DayIconPhrase { get; set; }
        public string DayPercipitationType { get; set; }
        public string DayPercipitationIntesity { get; set;}

        public int NightIcon { get; set; }
        public bool NightHasPercipitation { get; set; }
        public string NightIconPhrase { get; set; }
        public string NightPercipitationType { get; set; }
        public string NightPercipitationIntesity { get; set;}
    }
}
