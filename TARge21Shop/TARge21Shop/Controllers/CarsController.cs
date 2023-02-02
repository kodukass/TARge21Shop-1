using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Car;
using TARge21Shop.Models.Spaceship;

namespace TARge21Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly ICarsServices _carsServices;
        private readonly IFilesServices _filesServices;

        public CarsController
        (
                TARge21ShopContext context,
                ICarsServices carsServices,
                IFilesServices filesServices
            )
        {
            _context = context;
            _carsServices = carsServices;
            _filesServices = filesServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Mark = x.Mark,
                    Type = x.Type,
                    Passangers = x.Passangers,
                    EnginePower = x.EnginePower
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarEditViewModel car = new CarEditViewModel();

            return View("Edit", car);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarEditViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Mark = vm.Mark,
                Type = vm.Type,
                Passangers = vm.Passangers,
                CargoSpace = vm.CargoSpace,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                EnginePower = vm.EnginePower,
                BuiltDate = vm.BuiltDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _carsServices.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carsServices.GetUpdate(id);

            if (car == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabases
                .Where(x => x.SpaceshipId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var dto = new CarEditViewModel()
            {
                Id = car.Id,
                Mark = car.Mark,
                Type = car.Type,
                Passangers = car.Passangers,
                CargoSpace = car.CargoSpace,
                MaintenanceCount = car.MaintenanceCount,
                LastMaintenance = car.LastMaintenance,
                EnginePower = car.EnginePower,
                BuiltDate = car.BuiltDate,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt,
                Image.AddRange(photos)
        };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarEditViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Mark = vm.Mark,
                Type = vm.Type,
                Passangers = vm.Passangers,
                CargoSpace = vm.CargoSpace,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                EnginePower = vm.EnginePower,
                BuiltDate = vm.BuiltDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId,
                }).ToArray()
            };

            var result = await _carsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);
            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabases
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new CarDetailsViewModel()
            {
                Id = car.Id,
                Mark = car.Mark,
                Type = car.Type,
                Passangers = car.Passangers,
                CargoSpace = car.CargoSpace,
                MaintenanceCount = car.MaintenanceCount,
                LastMaintenance = car.LastMaintenance,
                EnginePower = car.EnginePower,
                BuiltDate = car.BuiltDate,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt,
                Image.AddRange(photos)
        };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabases
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new CarDeleteViewModel()
            {
                Id = car.Id,
                Mark = car.Mark,
                Type = car.Type,
                Passangers = car.Passangers,
                CargoSpace = car.CargoSpace,
                MaintenanceCount = car.MaintenanceCount,
                LastMaintenance = car.LastMaintenance,
                EnginePower = car.EnginePower,
                BuiltDate = car.BuiltDate,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt,
                Image.AddRange(photos)
        };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ImageViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = file.ImageId
            };

            var image = await _filesServices.RemoveImage(dto);

            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
