using static TARge21Shop.Core.Dto.WeatherData.MainDto;

namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class OpenWeatherResultDto
    {
        public string Name { get; set; }
        public List<Weathers> Weather { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public double Speed { get; set; }
    }
}
