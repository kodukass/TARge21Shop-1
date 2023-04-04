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

            vm.Weathers = new List<OpenWeatherViewModel.Weather>();
            vm.Weathers.Add(new OpenWeatherViewModel.Weather());
            vm.Weathers[0].Main = dto.Main;

            vm.Mains = new OpenWeatherViewModel.Main();
            vm.Mains.Temp = dto.Temp;
            vm.Mains.Feels_like = dto.Feels_like;
            vm.Mains.Pressure = dto.Pressure;
            vm.Mains.Humidity = dto.Humidity;

            vm.Winds = new OpenWeatherViewModel.Wind();
            vm.Winds.Speed = dto.Speed;

            vm.Name = dto.Name;

            return View(vm);
        }
    }
}