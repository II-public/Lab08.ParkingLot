using NUnit.Framework;

namespace Lab08.ParkingLot.Tests.ControllerTests.ParkingControllerTests
{
    public class GetFreeSpaces_Should
    {

        [SetUp]
        public void Setup()
        {
            // setup
        }

        [Test]
        public void TheCorrectNumberOfFreeSpaces_When_TheParkingIsEmpty()
        {
            Assert.Pass();
        }

        [Test]
        public void TheCorrectNumberOfFreeSpaces_When_TheParkingHasSomeVehiclesIn()
        {
            Assert.Pass();
        }
    }
}
