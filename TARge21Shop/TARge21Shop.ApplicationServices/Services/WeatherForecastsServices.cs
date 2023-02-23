using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto.WeatherData;

namespace TARge21Shop.ApplicationServices.Services
{
    public class WeatherForecastsServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            string apikey = "wmt4pmVoYmCWzLisL1nUO36Ss8TAgAEg";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                weatherInfo.Headline.EffectiveDate = dto.EffectiveDate;
                weatherInfo.Headline.EffectiveEpochDate = dto.EffectiveEpochDate;
                weatherInfo.Headline.Severity = dto.Severity;
                weatherInfo.Headline.Text = dto.Text;
                weatherInfo.Headline.Category = dto.Category;
                weatherInfo.Headline.EndDate = dto.EndDate;
                weatherInfo.Headline.EndEpochDate = dto.EndEpochDate;

                weatherInfo.Headline.MobileLink = dto.MobileLink;
                weatherInfo.Headline.Link = dto.Link;

                weatherInfo.DailyForecasts[0].Date = dto.DailyForecastsDay;
                weatherInfo.DailyForecasts[0].EpochDate = dto.DailyForecastsEpochDate;

                weatherInfo.DailyForecasts[0].Temperature.Minimum.Value = dto.TempMinValue;
                weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit = dto.TempMinUnit;
                weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType = dto.TempMinUnitType;

                weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit = dto.TempMaxUnit;
                weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit = dto.TempMaxUnit;
                weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType = dto.TempMaxUnitType;

                weatherInfo.DailyForecasts[0].DayNightCycle.Icon = dto.DayNightIcon;
                weatherInfo.DailyForecasts[0].DayNightCycle.IconPhrase = dto.DayNightIconPhrase;
            }
            return dto;
        }
    }
}
