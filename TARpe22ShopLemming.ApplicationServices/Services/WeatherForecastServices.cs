using Nancy.Json;
using System.Net;
using TARpe22ShopLemming.Core.Dto.WeatherDto;

namespace TARpe22ShopLemming.ApplicationServices.Services
{
    public class WeatherForecastServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            string apikey = "";
            var url = $"http://dataservice.accumweather.com/forecasts/v1/daily/1day";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = (new JavaScriptSerializer().Deserialize<WeatherRootDto>(json));

                weatherInfo.Headline.EffectiveDate = dto.EffectiveDate;
                weatherInfo.Headline.EffectiveEpochDate = dto.EffectiveEpochDate;
                weatherInfo.Headline.Severity = dto.Severity;
                weatherInfo.Headline.Text = dto.Text;
                weatherInfo.Headline.Category = dto.Category;
                weatherInfo.Headline.EndDate = dto.EndDate;
                weatherInfo.Headline.EndEpochDate = dto.EndEpochDate;
                weatherInfo.Headline.MobileLink = dto.MobileLink;
                weatherInfo.Headline.Link = dto.Link;

                weatherInfo.DailyForecasts[0].Date = dto.DailyForecasts;
                weatherInfo.DailyForecasts[0].EpochDate = dto.DailyForecastsEpochDate;
                weatherInfo.DailyForecasts[0].Temperature.Minimum.Value = dto.TempMinValue;
                weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit = dto.TempMinUnit;
                weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType = dto.TempMinUnitType;
                weatherInfo.DailyForecasts[0].Temperature.Maximum.Value = dto.TempMaxValue;
                weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit = dto.TempMinUnit;
                weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType = dto.TempMinUnitType;
                weatherInfo.DailyForecasts[0].Day.Icon = dto.DayIcon;
                weatherInfo.DailyForecasts[0].Day.IconPhrase = dto.DayIconPhrase;
                weatherInfo.DailyForecasts[0].Day.HasPrecipitation = dto.DayHasPrecipitation;
                weatherInfo.DailyForecasts[0].Day.PrecipitationType = dto.DayPercipitationType;
                weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity = dto.DayPercipitationIntesity;
                weatherInfo.DailyForecasts[0].Night.Icon = dto.NightIcon;
                weatherInfo.DailyForecasts[0].Night.IconPhrase = dto.NightIconPhrase;
                weatherInfo.DailyForecasts[0].Night.HasPrecipitation = dto.NightHasPercipitation;
                weatherInfo.DailyForecasts[0].Night.PrecipitationType = dto.NightPercipitationType;
                weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity = dto.NightPercipitationIntesity;
            }
            return null;
        }
    }
}
