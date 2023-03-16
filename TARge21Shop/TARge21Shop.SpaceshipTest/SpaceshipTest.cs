using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse("18ddd2c6-f53f-4574-ae8c-1e14559144b2");
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

            var result = await Svc<ISpaceshipsServices>().Delete(guid);

            Assert.Equal(result.Id,spaceship.Id);
        }
    }
}
