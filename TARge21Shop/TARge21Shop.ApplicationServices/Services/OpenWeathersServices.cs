using Nancy.Json;
using System.Net;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationServices.Services
{
    public class OpenWeathersServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto)
        {
            //127964
            string apikey = "935a14337aaca171504b8689bcae1f51";
            var url = $"https://api.openweathermap.org/data/2.5/weather?lat=59.436962&lon=24.753574&appid=935a14337aaca171504b8689bcae1f51";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                dto.temp = weatherInfo.Main.temp;
                dto.feels_like = weatherInfo.Main.feels_like;
                dto.pressure = weatherInfo.Main.pressure;
                dto.humidity = weatherInfo.Main.humidity;

                dto.speed = weatherInfo.Main.speed;

                dto.main = weatherInfo.Main.main;

                dto.name = weatherInfo.Main.name;

                //dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;

                //dto.MobileLink = weatherInfo.Headline.MobileLink;
                //dto.Link = weatherInfo.Headline.Link;

                ////dto.DailyForecastsDay = weatherInfo.DailyForecasts[0].Date;
                ////dto.DailyForecastsEpochDate = weatherInfo.DailyForecasts[0].EpochDate;

                //dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                //dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                //dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                //dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                //dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                //dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                //dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                //dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                //dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                //dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                //dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                //dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                //dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                //dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                //dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                //dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;

            }

            return dto;
        }
    }
}