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
    public class VehicleExit_Should
    {
        private Mock<ILab08ParkingLotUnitOfWork> _lab08ParkingLotUnitOfWork;
        private IVehicleRatesService _vehicleRatesService;
        private ICalculatorService _calculatorService;
        private IRegisterService _registerService;
        private ParkingController _controller;

        [SetUp]
        public void Setup()
        {
            // setup
            _lab08ParkingLotUnitOfWork = new Mock<ILab08ParkingLotUnitOfWork>();
            _vehicleRatesService = new VehicleRatesService();
            _calculatorService = new CalculatorService(_lab08ParkingLotUnitOfWork.Object, _vehicleRatesService);
            _registerService = new RegisterService(_lab08ParkingLotUnitOfWork.Object, _calculatorService);
            _controller = new ParkingController(_registerService, _calculatorService);
        }

        [Test]
        public void Success()
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

            var vehicle = new ExitVehicleDTO()
            {
                VehicleNumber = "1234",
                ExitTime = DateTime.Now
            };

            VehicleExitResultModel result = _controller.VehicleExit(vehicle);

            Assert.IsTrue(result.IsSuccessful);
        }

        [Test]
        public void Fail_When_TheVehicleIsSomehowNotRegistered()
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

            var vehicle = new ExitVehicleDTO()
            {
                VehicleNumber = "12345",
                ExitTime = DateTime.Now
            };

            VehicleExitResultModel result = _controller.VehicleExit(vehicle);

            Assert.IsFalse(result.IsSuccessful);
        }
    }
}
