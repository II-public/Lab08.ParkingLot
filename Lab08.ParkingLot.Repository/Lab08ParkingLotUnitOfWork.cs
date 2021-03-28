using Lab08.ParkingLot.Data.Context;
using Lab08.ParkingLot.Data.Interfaces;
using Lab08.ParkingLot.Repository.Interfaces;

namespace Lab08.ParkingLot.Repository
{
    public class Lab08ParkingLotUnitOfWork : RepositoryBase<IRelatedToDBContext>, ILab08ParkingLotUnitOfWork
    {
        private readonly ParkingLotDBContext _parkingLotDBContext;

        public Lab08ParkingLotUnitOfWork(ParkingLotDBContext parkingLotDBContext)
            : base(parkingLotDBContext)
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
