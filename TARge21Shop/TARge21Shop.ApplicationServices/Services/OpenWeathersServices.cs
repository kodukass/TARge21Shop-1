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
            string apikey = "139ba5a0d23c561201dedbe803c8af18";
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.Name}&units=metric&APPID={apikey}";
            
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                OpenWeatherRootDto weatherResult = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);
                //var result = new JavaScriptSerializer().Deserialize<MainDto>(json);

                dto.Temp = Math.Round(weatherResult.Main.Temp);// - 272.15, 2);
                dto.Feels_like = Math.Round(weatherResult.Main.Feels_like);// - 272.15, 2);
                dto.Pressure = weatherResult.Main.Pressure;
                dto.Humidity = weatherResult.Main.Humidity;
                dto.Main = weatherResult.Weather[0].Main;
                dto.Description = weatherResult.Weather[0].Description;
                dto.Speed = weatherResult.Wind.Speed;
                dto.Lon = weatherResult.Coord.Lon;
                dto.Lat = weatherResult.Coord.Lat;
                dto.Name = weatherResult.Name;
                //dto.Weather = weatherResult.Weather[0].Description;
            }

            return dto;
        }
    }
}