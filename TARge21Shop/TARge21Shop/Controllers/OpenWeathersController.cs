using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.Weather;

namespace TARge21Shop.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;

        public OpenWeathersController
            (
            IOpenWeatherServices openWeatherServices
            )
        {
            _openWeatherServices = openWeatherServices;
        }
        public IActionResult Index()
        {
            OpenWeatherViewModel vm = new OpenWeatherViewModel();

            return View();
        }
        [HttpPost]
        public IActionResult ShowWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City1", "OpenWeathers");
            }

            return View();
        }

        [HttpGet]
        public IActionResult City1()
        {
            OpenWeatherResultDto dto = new OpenWeatherResultDto();
            OpenWeatherViewModel vm = new OpenWeatherViewModel();

            _openWeatherServices.WeatherDetail(dto);

            vm.temp = dto.temp;
            vm.feels_like = dto.feels_like;
            vm.pressure = dto.pressure;
            vm.humidity = dto.humidity;

            vm.speed = dto.speed;

            vm.main = dto.main;
            //vm.EffectiveDate = dto.EffectiveDate;
            //vm.EffectiveEpochDate = dto.EffectiveEpochDate;
            //vm.Severity = dto.Severity;
            //vm.Text = dto.Text;
            //vm.MobileLink = dto.MobileLink;
            //vm.Link = dto.Link;
            //vm.Category = dto.Category;

            //vm.TempMinValue = dto.TempMinValue;
            //vm.TempMinUnit = dto.TempMinUnit;
            //vm.TempMinUnitType = dto.TempMinUnitType;

            //vm.TempMaxValue = dto.TempMaxValue;
            //vm.TempMaxUnit = dto.TempMaxUnit;
            //vm.TempMaxUnitType = dto.TempMaxUnitType;

            //vm.DayIcon = dto.DayIcon;
            //vm.DayIconPhrase = dto.DayIconPhrase;
            //vm.DayHasPrecipitation = dto.DayHasPrecipitation;
            //vm.DayPrecipitationType = dto.DayPrecipitationType;
            //vm.DayPrecipitationIntensity = dto.DayPrecipitationIntensity;

            //vm.NightIcon = dto.NightIcon;
            //vm.NightIconPhrase = dto.NightIconPhrase;
            //vm.NightHasPrecipitation = dto.NightHasPrecipitation;
            //vm.NightPrecipitationType = dto.NightPrecipitationType;
            //vm.NightPrecipitationIntensity = dto.NightPrecipitationIntensity;

            return View(vm);
        }
    }
}