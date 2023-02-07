using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly TARge21ShopContext _context;
        private readonly IFilesServices _files;

        public CarsServices
            (
                TARge21ShopContext context,
                IFilesServices files
            )
        {
            _context = context;
            _files = files;
        }

        //public async Task<Car> Add(CarDto dto)
        //{
        //    FileToDatabase file = new FileToDatabase();

        //    var domain = new Car()
        //    {
        //        Id = Guid.NewGuid(),
        //        Mark = dto.Mark,
        //        Type = dto.Type,
        //        Passangers = dto.Passangers,
        //        CargoSpace = dto.CargoSpace,
        //        MaintenanceCount = dto.MaintenanceCount,
        //        LastMaintenance = dto.LastMaintenance,
        //        EnginePower = dto.EnginePower,
        //        BuiltDate = dto.BuiltDate,
        //        CreatedAt = DateTime.Now,
        //        ModifiedAt = DateTime.Now
        //    };
        //    if (dto.Files != null)
        //    {
        //        _files.UploadFilesToDatabaseCar(dto, Car);
        //    }

        //    await _context.Cars.AddAsync(domain);
        //    await _context.SaveChangesAsync();
        //    return domain;
        //}
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();
            FileToDatabase file = new FileToDatabase();

            car.Id = Guid.NewGuid();
            car.Mark = dto.Mark;
            car.Type = dto.Type;
            car.Passangers = dto.Passangers;
            car.CargoSpace = dto.CargoSpace;
            car.MaintenanceCount = dto.MaintenanceCount;
            car.LastMaintenance = dto.LastMaintenance;
            car.EnginePower = dto.EnginePower;
            car.BuiltDate = dto.BuiltDate;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabaseCar(dto, car);
            }


            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Update(CarDto dto)
        {
            var domain = new Car()
            {
                Id = dto.Id,
                Mark = dto.Mark,
                Type = dto.Type,
                Passangers = dto.Passangers,
                CargoSpace = dto.CargoSpace,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                EnginePower = dto.EnginePower,
                BuiltDate = dto.BuiltDate,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now
            };

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabaseCar(dto, domain);
            }

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<Car> GetUpdate(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToDatabases
                .Where(x => x.CarId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    CarId = y.CarId,
                })
                .ToArrayAsync();

            await _files.RemoveImagesFromDatabase(images);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }


    }
}
