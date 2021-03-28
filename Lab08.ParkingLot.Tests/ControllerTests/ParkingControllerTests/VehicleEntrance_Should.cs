using NUnit.Framework;

namespace Lab08.ParkingLot.Tests.ControllerTests.ParkingControllerTests
{
    public class VehicleEntrance_Should
    {
        [SetUp]
        public void Setup()
        {
            // setup
        }

        [Test]
        public void Success_When_TheThereAreFreeParkingSpaces()
        {
            Assert.Pass();
        }

        [Test]
        public void Success_When_TheThereAreEnoughFreeParkingSpacesForVehicleCatB()
        {
            Assert.Pass();
        }

        [Test]
        public void Success_When_TheThereAreEnoughFreeParkingSpacesForVehicleCatC()
        {
            Assert.Pass();
        }

        [Test]
        public void Fail_When_TheParkingIsFull()
        {
            Assert.Pass();
        }

        [Test]
        public void Fail_When_TheThereAreNotEnoughFreeParkingSpacesForVehicleCatB()
        {
            Assert.Pass();
        }

        [Test]
        public void Fail_When_TheThereAreNotEnoughFreeParkingSpacesForVehicleCatC()
        {
            Assert.Pass();
        }
    }
}
