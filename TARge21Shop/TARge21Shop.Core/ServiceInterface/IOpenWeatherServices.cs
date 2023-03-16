using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto.WeatherData;
using TARge21Shop.Core.Dto.WeatherDtos;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
        Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto);
    }
}