using System;
using System;
using TARge21Shop.Core.Dto.WeatherDtos;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
        Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto);
    }
}