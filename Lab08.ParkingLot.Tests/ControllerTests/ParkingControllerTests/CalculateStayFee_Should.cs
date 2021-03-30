using System;
using System.Collections.Generic;
using System.Linq;
using Lab08.ParkingLot.Controllers;
using Lab08.ParkingLot.Data.DataBase;
using Lab08.ParkingLot.DTO;
using Lab08.ParkingLot.Enums;
using Lab08.ParkingLot.Model;
using Lab08.ParkingLot.Repository.Interfaces;
using Lab08.ParkingLot.Service;
using Lab08.ParkingLot.Service.Interfaces;
using Moq;
using NUnit.Framework;

namespace Lab08.ParkingLot.Tests.ControllerTests.ParkingControllerTests
{
    public class CalculateStayFee_Should
    {
        private Mock<ILab08ParkingLotUnitOfWork> _lab08ParkingLotUnitOfWork;
        private IRegisterService _registerService;
        private ICalculatorService _calculatorService;
        private IVehicleRatesService _vehicleRatesService;
        private ParkingController _controller;

        [SetUp]
        public void Setup()
        {
            // setup
            _lab08ParkingLotUnitOfWork = new Mock<ILab08ParkingLotUnitOfWork>();
            _registerService = new RegisterService(_lab08ParkingLotUnitOfWork.Object);
            _vehicleRatesService = new VehicleRatesService();
            _calculatorService = new CalculatorService(_lab08ParkingLotUnitOfWork.Object, _vehicleRatesService);
            _controller = new ParkingController(_registerService, _calculatorService);
        }

        [Test]
        [TestCase(14, 18)]
        [TestCase(19, 29)]
        [TestCase(23, 37)]
        public void TheCorrectNumber_When_TheParkingIsCatANoDiscountCardAfterBeforeDailyRates(int endHour, int fee)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle()
                {
                    Number = "1234",
                    EntryTime = new DateTime(2021, 3, 30, 9, 15, 0),
                    VehicleCategory = VehicleCategory.A
                }
            };

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehicles.AsQueryable());

            var vehicleCalc = new VehicleFeeCalculationDTO()
            {
                VehicleNumber = "1234",
                EntranceTime = new DateTime(2021, 3, 30, endHour, 15, 0),
            };

            VehicleCalculationResultModel result = _controller.CalculateStayFee(vehicleCalc);

            Assert.AreEqual(fee, result.Fee);
        }

        [Test]
        [TestCase(14, 30)]
        [TestCase(19, 44)]
        [TestCase(23, 52)]
        public void TheCorrectNumber_When_TheParkingIsCatANoDiscountCardEntranceBeforeDailyRates(int endHour, int fee)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle()
                {
                    Number = "1234",
                    EntryTime = new DateTime(2021, 3, 30, 2, 15, 0),
                    VehicleCategory = VehicleCategory.A
                }
            };

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehicles.AsQueryable());

            var vehicleCalc = new VehicleFeeCalculationDTO()
            {
                VehicleNumber = "1234",
                EntranceTime = new DateTime(2021, 3, 30, endHour, 15, 0),
            };

            VehicleCalculationResultModel result = _controller.CalculateStayFee(vehicleCalc);

            Assert.AreEqual(fee, result.Fee);
        }

        [Test]
        public void TheCorrectNumber_When_TheParkingIsCatBAndNoDiscountCard()
        {
            Assert.Pass();
        }

        [Test]
        public void TheCorrectNumber_When_TheParkingIsCatCAndNoDiscountCard()
        {
            Assert.Pass();
        }

        [Test]
        public void TheCorrectNumber_When_TheParkingIsCatAAndThereIsDiscountCard()
        {
            Assert.Pass();
        }

        [Test]
        public void TheCorrectNumber_When_TheParkingIsCatBAndThereIsDiscountCard()
        {
            Assert.Pass();
        }

        [Test]
        public void TheCorrectNumber_When_TheParkingIsCatCAndThereIsDiscountCard()
        {
            Assert.Pass();
        }
    }
}
