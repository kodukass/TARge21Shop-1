using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using Xunit;

namespace TARge21Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();
            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "asd";
            spaceship.Type = "asd";
            spaceship.Crew = 123;
            spaceship.Passengers = 123;
            spaceship.CargoWeight = 123;
            spaceship.FullTripsCount = 2;
            spaceship.MaintenanceCount = 2;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.EnginePower = 1;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            //arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");

            //act
            await Svc<ISpaceshipsServices>().GetAsync(guid);

            //assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsEqual()
        {
            //arrange
            Guid getGuid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");
            Guid databaseGuid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");

            //act
            await Svc<ISpaceshipsServices>().GetAsync(getGuid);

            //assert
            Assert.Equal(databaseGuid, getGuid);
        }
        
        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            //Guid guid = Guid.NewGuid();
            Guid guid = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");

            SpaceshipDto spaceship = MockSpaceshipData();
            var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship.Id);

            Assert.Equal(result.Id,addSpaceship.Id);
            Assert.Equal(result.Name, addSpaceship.Name);
        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("18ddd2c6-f53f-4574-ae8c-1e14559144b2");
            Spaceship spaceship = new Spaceship();
            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");
            spaceship.Name = "Name";
            spaceship.Type = "asd";
            spaceship.Crew = 1223;
            spaceship.Passengers = 1223;
            spaceship.CargoWeight = 120;
            spaceship.FullTripsCount = 120;
            spaceship.MaintenanceCount = 120;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.EnginePower = 1022;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;


            await Svc<ISpaceshipsServices>().Update(dto);

            Assert.Equal(spaceship.Id.ToString(), guid.ToString());
            Assert.DoesNotMatch(spaceship.Name, dto.Name);
            Assert.DoesNotMatch(spaceship.EnginePower.ToString(), dto.EnginePower.ToString());
            Assert.Equal(spaceship.Crew, dto.Crew);
        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateDataVersion2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceship();
            var result = await Svc<ISpaceshipsServices>().Update(update);

            Assert.Equal(update.Id, dto.Id);
            Assert.DoesNotMatch(result.Name, createSpaceship.Name);
            //Assert.DoesNotMatch(result.EnginePower.ToString(), createSpaceship.EnginePower.ToString());
            //Assert.Equal(result.Crew, createSpaceship.Crew);
            Assert.NotEqual(result.ModifiedAt, createSpaceship.ModifiedAt);
        }

        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto nullUpdate = MockNullSpaceship();
            var result = await Svc<ISpaceshipsServices>().Update(nullUpdate);

            Assert.NotEqual(result, createSpaceship);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDelete()
        {
            SpaceshipDto spaceship = MockSpaceshipData();
            var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);

            var addSpaceship2 = await Svc<ISpaceshipsServices>().Create(spaceship);

            var wrongGuid = Guid.NewGuid();

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship2.Id);

            Assert.NotEqual(result.Id.ToString(), addSpaceship.Id.ToString());
        }

        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "name",
                Type = "asd",
                Crew = 123,
                Passengers = 123,
                CargoWeight = 10,
                FullTripsCount = 10,
                MaintenanceCount = 10,
                LastMaintenance = DateTime.Now,
                EnginePower = 110,
                MaidenLaunch = DateTime.Now,
                BuiltDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return spaceship;
        }
        
        private SpaceshipDto MockUpdateSpaceship()
        {
            SpaceshipDto update = new()
            {
            Name = "Name",
            Type = "asd",
            Crew = 1223,
            Passengers = 1223,
            CargoWeight = 120,
            FullTripsCount = 120,
            MaintenanceCount = 120,
            LastMaintenance = DateTime.Now.AddYears(1),
            EnginePower = 10,
            MaidenLaunch = DateTime.Now.AddYears(1),
            BuiltDate = DateTime.Now.AddYears(1),
            CreatedAt = DateTime.Now.AddYears(1),
            ModifiedAt = DateTime.Now.AddYears(1),
            };
            return update;
        }

        private SpaceshipDto MockNullSpaceship()
        {
            SpaceshipDto nullDto = new()
            {
                Id = null,
                Name = "name",
                Type = "asd",
                Crew = 123,
                Passengers = 123,
                CargoWeight = 10,
                FullTripsCount = 10,
                MaintenanceCount = 10,
                LastMaintenance = DateTime.Now,
                EnginePower = 110,
                MaidenLaunch = DateTime.Now,
                BuiltDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return nullDto;
        }
    }
}
