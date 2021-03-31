using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
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
    public class VehicleEntrance_Should
    {
        private Mock<ILab08ParkingLotUnitOfWork> _lab08ParkingLotUnitOfWork;
        private Mock<IVehicleRatesService> _vehicleRatesService;
        private ICalculatorService _calculatorService;
        private IRegisterService _registerService;
        private ParkingController _controller;
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            // setup
            _lab08ParkingLotUnitOfWork = new Mock<ILab08ParkingLotUnitOfWork>();
            _vehicleRatesService = new Mock<IVehicleRatesService>();
            _calculatorService = new CalculatorService(_lab08ParkingLotUnitOfWork.Object, _vehicleRatesService.Object);
            _registerService = new RegisterService(_lab08ParkingLotUnitOfWork.Object, _calculatorService);
            _controller = new ParkingController(_registerService, _calculatorService);

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.Insert(It.IsAny<Vehicle>())).Verifiable();

            _fixture = new Fixture();
        }

        [Test]
        public void Success_When_TheThereAreFreeParkingSpaces()
        {
            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(new List<Vehicle>().AsQueryable());

            var vehicle = new RegisterVehicleDTO()
            {
                VehicleNumber = It.IsAny<string>(),
                EntranceTime = It.IsAny<DateTime>(),
                VehicleCategory = It.IsAny<VehicleCategory>()
            };

            VehicleEntranceResultModel result = _controller.VehicleEntrance(vehicle);

            Assert.IsTrue(result.IsSuccessful);
        }

        [Test]
        public void Success_When_TheThereAreEnoughFreeParkingSpacesForVehicleCatB()
        {
            var vehiclesInsideTheParkingLot = _fixture.Build<Vehicle>()
                                                      .With(v => v.VehicleCategory, VehicleCategory.C)
                                                      .CreateMany(49)
                                                      .ToList();

            vehiclesInsideTheParkingLot.Add(
                    _fixture.Build<Vehicle>()
                    .With(v => v.VehicleCategory, VehicleCategory.A)
                    .Create()
                );

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehiclesInsideTheParkingLot.AsQueryable());

            RegisterVehicleDTO vehicle = _fixture.Build<RegisterVehicleDTO>()
                                  .With(v => v.VehicleCategory, VehicleCategory.B)
                                  .Create();

            VehicleEntranceResultModel result = _controller.VehicleEntrance(vehicle);

            Assert.IsTrue(result.IsSuccessful);
        }

        [Test]
        public void Success_When_TheThereAreEnoughFreeParkingSpacesForVehicleCatC()
        {
            var vehiclesInsideTheParkingLot = _fixture.Build<Vehicle>()
                                                      .With(v => v.VehicleCategory, VehicleCategory.C)
                                                      .CreateMany(49)
                                                      .ToList();

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehiclesInsideTheParkingLot.AsQueryable());

            RegisterVehicleDTO vehicle = _fixture.Build<RegisterVehicleDTO>()
                                  .With(v => v.VehicleCategory, VehicleCategory.C)
                                  .Create();

            VehicleEntranceResultModel result = _controller.VehicleEntrance(vehicle);

            Assert.IsTrue(result.IsSuccessful);
        }

        [Test]
        public void Fail_When_TheParkingIsFull()
        {
            var vehiclesInsideTheParkingLot = _fixture.Build<Vehicle>()
                                          .With(v => v.VehicleCategory, VehicleCategory.C)
                                          .CreateMany(50)
                                          .ToList();

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehiclesInsideTheParkingLot.AsQueryable());

            RegisterVehicleDTO vehicle = _fixture.Build<RegisterVehicleDTO>()
                                  .With(v => v.VehicleCategory, VehicleCategory.B)
                                  .Create();

            VehicleEntranceResultModel result = _controller.VehicleEntrance(vehicle);

            Assert.IsFalse(result.IsSuccessful);
        }

        [Test]
        public void Fail_When_TheThereAreNotEnoughFreeParkingSpacesForVehicleCatB()
        {
            var vehiclesInsideTheParkingLot = _fixture.Build<Vehicle>()
                                          .With(v => v.VehicleCategory, VehicleCategory.C)
                                          .CreateMany(49)
                                          .ToList();

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehiclesInsideTheParkingLot.AsQueryable());

            vehiclesInsideTheParkingLot.AddRange(
                    _fixture.Build<Vehicle>()
                    .With(v => v.VehicleCategory, VehicleCategory.A)
                    .CreateMany(3)
                );

            RegisterVehicleDTO vehicle = _fixture.Build<RegisterVehicleDTO>()
                                  .With(v => v.VehicleCategory, VehicleCategory.B)
                                  .Create();

            VehicleEntranceResultModel result = _controller.VehicleEntrance(vehicle);

            Assert.IsFalse(result.IsSuccessful);
        }

        [Test]
        public void Fail_When_TheThereAreNotEnoughFreeParkingSpacesForVehicleCatC()
        {
            var vehiclesInsideTheParkingLot = _fixture.Build<Vehicle>()
                                                      .With(v => v.VehicleCategory, VehicleCategory.C)
                                                      .CreateMany(49)
                                                      .ToList();

            vehiclesInsideTheParkingLot.Add(
                    _fixture.Build<Vehicle>()
                    .With(v => v.VehicleCategory, VehicleCategory.A)
                    .Create()
                );

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehiclesInsideTheParkingLot.AsQueryable());

            RegisterVehicleDTO vehicle = _fixture.Build<RegisterVehicleDTO>()
                                  .With(v => v.VehicleCategory, VehicleCategory.C)
                                  .Create();

            VehicleEntranceResultModel result = _controller.VehicleEntrance(vehicle);

            Assert.IsFalse(result.IsSuccessful);
        }
    }
}
