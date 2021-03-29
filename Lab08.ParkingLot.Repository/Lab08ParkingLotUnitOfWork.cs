using Lab08.ParkingLot.Data.Context;
using Lab08.ParkingLot.Repository.Interfaces;

namespace Lab08.ParkingLot.Repository
{
    public class Lab08ParkingLotUnitOfWork : ILab08ParkingLotUnitOfWork
    {
        private readonly ParkingLotDBContext _parkingLotDBContext;

        private IVehicleRepository _vehicleRepository;

        public IVehicleRepository VehicleRepository
        {
            get
            {
                if (_vehicleRepository == null)
                {
                    _vehicleRepository = new VehicleRepository(_parkingLotDBContext);
                }

                return _vehicleRepository;
            }
        }

        public Lab08ParkingLotUnitOfWork(ParkingLotDBContext parkingLotDBContext)
        {
            _parkingLotDBContext = parkingLotDBContext;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _parkingLotDBContext.SaveChanges();
        }
    }
}
