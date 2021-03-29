using Lab08.ParkingLot.Data.Context;
using Lab08.ParkingLot.Data.DataBase;
using Lab08.ParkingLot.Repository.Interfaces;

namespace Lab08.ParkingLot.Repository
{
    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ParkingLotDBContext dataContext) : base(dataContext)
        {
        }
    }
}
