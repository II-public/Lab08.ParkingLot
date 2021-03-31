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
        [TestCase(14, 60)]
        [TestCase(19, 88)]
        [TestCase(23, 104)]
        public void TheCorrectNumber_When_TheParkingIsCatBAndNoDiscountCard(int endHour, int fee)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle()
                {
                    Number = "1234",
                    EntryTime = new DateTime(2021, 3, 30, 2, 15, 0),
                    VehicleCategory = VehicleCategory.B
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
        [TestCase(14, 120)]
        [TestCase(19, 176)]
        [TestCase(23, 208)]
        public void TheCorrectNumber_When_TheParkingIsCatCAndNoDiscountCard(int endHour, int fee)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle()
                {
                    Number = "1234",
                    EntryTime = new DateTime(2021, 3, 30, 2, 15, 0),
                    VehicleCategory = VehicleCategory.C
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
        [TestCase(14, 24)]
        [TestCase(19, 35.20)]
        [TestCase(23, 41.60)]
        public void TheCorrectNumber_When_TheParkingIsCatAAndThereIsDiscountCard(int endHour, double fee)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle()
                {
                    Number = "1234",
                    EntryTime = new DateTime(2021, 3, 30, 2, 15, 0),
                    DiscountCard = DiscountCard.Platinum,
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
        [TestCase(14, 51)]
        [TestCase(19, 74.80)]
        [TestCase(23, 88.40)]
        public void TheCorrectNumber_When_TheParkingIsCatBAndThereIsDiscountCard(int endHour, double fee)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle()
                {
                    Number = "1234",
                    EntryTime = new DateTime(2021, 3, 30, 2, 15, 0),
                    DiscountCard = DiscountCard.Gold,
                    VehicleCategory = VehicleCategory.B
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
        [TestCase(14, 108)]
        [TestCase(19, 158.40)]
        [TestCase(23, 187.20)]
        public void TheCorrectNumber_When_TheParkingIsCatCAndThereIsDiscountCard(int endHour, double fee)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle()
                {
                    Number = "1234",
                    EntryTime = new DateTime(2021, 3, 30, 2, 15, 0),
                    DiscountCard = DiscountCard.Silver,
                    VehicleCategory = VehicleCategory.C
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
    }
}
