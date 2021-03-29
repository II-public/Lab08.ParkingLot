using System.Linq;
using Lab08.ParkingLot.Data.DataBase;
using Lab08.ParkingLot.Repository.Interfaces;
using Lab08.ParkingLot.Service.Interfaces;

namespace Lab08.ParkingLot.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly ILab08ParkingLotUnitOfWork _lab08ParkingLotUnitOfWork;

        public RegisterService(ILab08ParkingLotUnitOfWork lab08ParkingLotUnitOfWork)
        {
            _lab08ParkingLotUnitOfWork = lab08ParkingLotUnitOfWork;
        }

        public int GetFreeSpaces()
        {
            IQueryable<Vehicle> vehiclesinTheParkingLog = _lab08ParkingLotUnitOfWork.VehicleRepository.GetAll();

            int spacesOccupied = vehiclesinTheParkingLog.Any() ? vehiclesinTheParkingLog.Sum(v => (int)v.VehicleCategory) : 0;

            return 200 - spacesOccupied;
        }

        public bool VehicleEntrance()
        {
            throw new System.NotImplementedException();
        }

        public bool VehicleExit()
        {
            throw new System.NotImplementedException();
        }
    }
}
