using System.Linq;
using Lab08.ParkingLot.Data.DataBase;
using Lab08.ParkingLot.DTO;
using Lab08.ParkingLot.Model;
using Lab08.ParkingLot.Repository.Interfaces;
using Lab08.ParkingLot.Service.Interfaces;

namespace Lab08.ParkingLot.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly ILab08ParkingLotUnitOfWork _lab08ParkingLotUnitOfWork;
        private readonly ICalculatorService _calculatorService;

        public RegisterService(
            ILab08ParkingLotUnitOfWork lab08ParkingLotUnitOfWork,
            ICalculatorService calculatorService)
        {
            _lab08ParkingLotUnitOfWork = lab08ParkingLotUnitOfWork;
            _calculatorService = calculatorService;
        }

        public int GetFreeSpaces()
        {
            IQueryable<Vehicle> vehiclesinTheParkingLog = _lab08ParkingLotUnitOfWork.VehicleRepository.GetAll();

            int spacesOccupied = vehiclesinTheParkingLog.Any() ? vehiclesinTheParkingLog.Sum(v => (int)v.VehicleCategory) : 0;

            return 200 - spacesOccupied;
        }

        public VehicleEntranceResultModel VehicleEntrance(RegisterVehicleDTO registerVehicleDTO)
        {
            int freeSpaces = GetFreeSpaces();

            if (freeSpaces < (int)registerVehicleDTO.VehicleCategory)
            {
                return new VehicleEntranceResultModel()
                {
                    IsSuccessful = false,
                    Message = "There are not enough spaces!"
                };
            }

            bool vehicleAlreadyRegistered = _lab08ParkingLotUnitOfWork.VehicleRepository.GetAll().Any(v => v.Number == registerVehicleDTO.VehicleNumber);

            if (vehicleAlreadyRegistered)
            {
                return new VehicleEntranceResultModel()
                {
                    IsSuccessful = false,
                    Message = "Vehicle is already registered in this parking lot!"
                };
            }

            _lab08ParkingLotUnitOfWork.VehicleRepository.Insert(new Vehicle()
            {
                Number = registerVehicleDTO.VehicleNumber,
                VehicleCategory = registerVehicleDTO.VehicleCategory,
                EntryTime = registerVehicleDTO.EntranceTime,
                DiscountCard = registerVehicleDTO.DiscountCard
            });

            _lab08ParkingLotUnitOfWork.Save();

            return new VehicleEntranceResultModel()
            {
                IsSuccessful = true,
                Message = $"Welcome {registerVehicleDTO.VehicleNumber}, we wish you a nice stay with us!"
            };
        }

        public VehicleExitResultModel VehicleExit(ExitVehicleDTO exitVehicleDTO)
        {
            Vehicle vehicle = _lab08ParkingLotUnitOfWork.VehicleRepository.GetAll().FirstOrDefault(v => v.Number == exitVehicleDTO.VehicleNumber);

            if (vehicle == null)
            {
                return new VehicleExitResultModel()
                {
                    IsSuccessful = false,
                    Message = $"Vehicle {exitVehicleDTO.VehicleNumber} cant be found in the parking lot!",
                    Fee = 0
                };
            }

            double calculatedFee = _calculatorService.CalculateFee(new VehicleFeeCalculationDTO()
            {
                VehicleNumber = vehicle.Number,
                EntranceTime = exitVehicleDTO.ExitTime
            }).Fee;

            return new VehicleExitResultModel()
            {
                IsSuccessful = true,
                Message = $"Vehicle {exitVehicleDTO.VehicleNumber} can now leave the parking lot.",
                Fee = calculatedFee
            };
        }
    }
}
