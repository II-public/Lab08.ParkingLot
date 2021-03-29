using System.Collections.Generic;
using System.Linq;
using Lab08.ParkingLot.Controllers;
using Lab08.ParkingLot.Data.DataBase;
using Lab08.ParkingLot.Repository.Interfaces;
using Lab08.ParkingLot.Service;
using Lab08.ParkingLot.Service.Interfaces;
using Moq;
using NUnit.Framework;

namespace Lab08.ParkingLot.Tests.ControllerTests.ParkingControllerTests
{
    public class GetFreeSpaces_Should
    {
        private Mock<ILab08ParkingLotUnitOfWork> _lab08ParkingLotUnitOfWork;
        private IRegisterService _registerService;
        private ParkingController _controller;

        [SetUp]
        public void Setup()
        {
            _lab08ParkingLotUnitOfWork = new Mock<ILab08ParkingLotUnitOfWork>();
            _registerService = new RegisterService(_lab08ParkingLotUnitOfWork.Object);
            _controller = new ParkingController(_registerService);
        }

        [Test]
        public void TheCorrectNumberOfFreeSpaces_When_TheParkingIsEmpty()
        {
            // hey, I have just met you
            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(new List<Vehicle>().AsQueryable());

            // but here is my number
            int freeSpaces = _controller.GetFreeSpaces();

            // so call me maybe
            Assert.AreEqual(200, freeSpaces);
        }

        [Test]
        public void TheCorrectNumberOfFreeSpaces_When_TheParkingHas1CatBVehicle()
        {
            // setup
            var vehicles = new List<Vehicle>()
            {
                new Vehicle() { Number = It.IsAny<string>(), VehicleCategory = Enums.VehicleCategory.B }
            };

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehicles.AsQueryable());

            // act
            int freeSpaces = _controller.GetFreeSpaces();

            // assert
            Assert.AreEqual(198, freeSpaces);
        }

        [Test]
        public void TheCorrectNumberOfFreeSpaces_When_TheParkingHas2CatAAnd1CatBVehicles()
        {
            // setup
            var vehicles = new List<Vehicle>()
            {
                new Vehicle() { Number = It.IsAny<string>(), VehicleCategory = Enums.VehicleCategory.A },
                new Vehicle() { Number = It.IsAny<string>(), VehicleCategory = Enums.VehicleCategory.A },
                new Vehicle() { Number = It.IsAny<string>(), VehicleCategory = Enums.VehicleCategory.B }
            };

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehicles.AsQueryable());

            // act
            int freeSpaces = _controller.GetFreeSpaces();

            // assert
            Assert.AreEqual(196, freeSpaces);
        }

        [Test]
        public void TheCorrectNumberOfFreeSpaces_When_TheParkingHas2CatA1CatBAnd2CatCVehicles()
        {
            // setup
            var vehicles = new List<Vehicle>()
            {
                new Vehicle() { Number = It.IsAny<string>(), VehicleCategory = Enums.VehicleCategory.A },
                new Vehicle() { Number = It.IsAny<string>(), VehicleCategory = Enums.VehicleCategory.A },
                new Vehicle() { Number = It.IsAny<string>(), VehicleCategory = Enums.VehicleCategory.B },
                new Vehicle() { Number = It.IsAny<string>(), VehicleCategory = Enums.VehicleCategory.C }
            };

            _lab08ParkingLotUnitOfWork.Setup(r => r.VehicleRepository.GetAll()).Returns(vehicles.AsQueryable());

            // act
            int freeSpaces = _controller.GetFreeSpaces();

            // assert
            Assert.AreEqual(192, freeSpaces);
        }
    }
}
