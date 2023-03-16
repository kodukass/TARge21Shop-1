using TARge21Shop.Core.Dto.WeatherData;

namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class WeatherRootDto
    {
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastsDto> DailyForecasts { get; set; }
        public MainDto Main { get; set; }
        public MainDto Weather { get; set; }
        public MainDto Wind { get; set; }
    }
}