using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TARpe22ShopLemming.Core.Dto;
using TARpe22ShopLemming.Core.ServiceInterface;
using Xunit;

namespace TARpe22ShopLemming.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Price = 100;
            spaceship.Type = "roclet";
            spaceship.Name = "X ae A 12";
            spaceship.Description = "Description";
            spaceship.FuelType = "CowFarts";
            spaceship.FuelCapacity = 100;
            spaceship.FuelConsumption = 100;
            spaceship.PassengerCount = 100;
            spaceship.EnginePower = 100;
            spaceship.DoesHaveAutopilot = true;
            spaceship.CrewCount = 100;
            spaceship.CargoWeight = 100;
            spaceship.DoesHaveLifeSupportSystems = true;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.MaintenanceCount = 1;
            spaceship.FullTripsCount = 1;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Space Z";
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            spaceship.Files = new List<IFormFile>();


            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.IsNotNull(result);

        }
    }
}
