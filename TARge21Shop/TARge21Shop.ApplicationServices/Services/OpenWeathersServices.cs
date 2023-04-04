using Nancy.Json;
using System.Net;
using TARge21Shop.Core.Dto.WeatherData;
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
            var url = $"https://api.openweathermap.org/data/2.5/weather?weather?lat=59.436962&lon=24.753574&APPID=935a14337aaca171504b8689bcae1f51";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);
                var result = new JavaScriptSerializer().Deserialize<MainDto>(json);

                dto.Temp = Math.Round(result.Main.Temp - 272.15, 2);
                dto.Feels_like = Math.Round(result.Main.Feels_like - 272.15, 2);
                dto.Pressure = result.Main.Pressure;
                dto.Humidity = result.Main.Humidity;
                dto.Main = result.Weather[0].Main;
                dto.Description = result.Weather[0].Description;
                dto.Speed = result.Wind.Speed;
                dto.Lon = result.Coord.Lon;
                dto.Lat = result.Coord.Lat;
                dto.Name = result.Name;
                dto.Weather = result.Weather;
            }

            return dto;
        }
    }
}