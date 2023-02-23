using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TARge21Shop.Core.Dto.WeatherData.DailyForecastsDto;

namespace TARge21Shop.Core.Dto.WeatherData
{
    public class WeatherRootDto
    {
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastsDto> DailyForecasts { get; set; }
    }
}
