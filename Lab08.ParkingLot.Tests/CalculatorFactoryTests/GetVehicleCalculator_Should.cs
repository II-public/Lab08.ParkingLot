using Lab08.ParkingLot.Enums;
using Lab08.ParkingLot.Service.Calculators;
using Lab08.ParkingLot.Service.Interfaces;
using NUnit.Framework;

namespace Lab08.ParkingLot.Tests.CalculatorFactoryTests
{
    public class GetVehicleCalculator_Should
    {
        private ICalculatorFactory _calculatorFactory;

        [SetUp]
        public void Setup()
        {
            _calculatorFactory = new CalculatorFactory();
        }

        [Test]
        public void TheCorrectCalculatorType_When_CatAIsPassed()
        {
            IVehicleCalculator calculator = _calculatorFactory.GetVehicleCalculator(VehicleCategory.A);
            Assert.IsTrue(calculator is VehicleCalculatorCatA);
        }

        [Test]
        public void TheCorrectCalculatorType_When_CatBIsPassed()
        {
            IVehicleCalculator calculator = _calculatorFactory.GetVehicleCalculator(VehicleCategory.B);
            Assert.IsTrue(calculator is VehicleCalculatorCatB);
        }

        [Test]
        public void TheCorrectCalculatorType_When_CatCIsPassed()
        {
            IVehicleCalculator calculator = _calculatorFactory.GetVehicleCalculator(VehicleCategory.C);
            Assert.IsTrue(calculator is VehicleCalculatorCatC);
        }
    }
}
