using Lab08.ParkingLot.Enums;
using Lab08.ParkingLot.Model;
using Lab08.ParkingLot.Service;
using Lab08.ParkingLot.Service.Interfaces;
using NUnit.Framework;

namespace Lab08.ParkingLot.Tests.ServicesTests.VehicleRatesServiceTests
{
    public class GetRatesByVehicleCategory_Should
    {
        private IVehicleRatesService _vehicleRatesService;

        [SetUp]
        public void Setup()
        {
            _vehicleRatesService = new VehicleRatesService();
        }

        [Test]
        [TestCase(VehicleCategory.A)]
        public void ReturnCorrectVehicleRate_When_VehicleCatAIsPassed(VehicleCategory vehicleCategory)
        {
            var expectedResult = new VehicleRatesModel
            {
                DayLightRates = 3,
                NightlyRates = 2
            };

            VehicleRatesModel actualResult = _vehicleRatesService.GetRatesByVehicleCategory(vehicleCategory);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(VehicleCategory.B)]
        public void ReturnCorrectVehicleRate_When_VehicleCatBIsPassed(VehicleCategory vehicleCategory)
        {
            var expectedResult = new VehicleRatesModel
            {
                DayLightRates = 6,
                NightlyRates = 4
            };

            VehicleRatesModel actualResult = _vehicleRatesService.GetRatesByVehicleCategory(vehicleCategory);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(VehicleCategory.C)]
        public void ReturnCorrectVehicleRate_When_VehicleCatCIsPassed(VehicleCategory vehicleCategory)
        {
            var expectedResult = new VehicleRatesModel
            {
                DayLightRates = 12,
                NightlyRates = 8
            };

            VehicleRatesModel actualResult = _vehicleRatesService.GetRatesByVehicleCategory(vehicleCategory);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
