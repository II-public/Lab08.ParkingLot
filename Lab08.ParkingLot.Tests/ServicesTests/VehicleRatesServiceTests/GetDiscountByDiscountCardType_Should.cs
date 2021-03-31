using Lab08.ParkingLot.Enums;
using Lab08.ParkingLot.Service;
using Lab08.ParkingLot.Service.Interfaces;
using NUnit.Framework;

namespace Lab08.ParkingLot.Tests.ServicesTests.VehicleRatesServiceTests
{
    public class GetDiscountByDiscountCardType_Should
    {
        private IVehicleRatesService _vehicleRatesService;

        [SetUp]
        public void Setup()
        {
            _vehicleRatesService = new VehicleRatesService();
        }

        [Test]
        [TestCase(10, DiscountCard.Silver)]
        [TestCase(15, DiscountCard.Gold)]
        [TestCase(20, DiscountCard.Platinum)]
        [TestCase(0, DiscountCard.None)]
        public void ReturnCorrectDiscount_For_CorespondingCardIsPassed(int expectedResult, DiscountCard discountCard)
        {
            int actualResult = _vehicleRatesService.GetDiscountByDiscountCardType(discountCard);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
