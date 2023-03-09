using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;

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
       
    }
}
