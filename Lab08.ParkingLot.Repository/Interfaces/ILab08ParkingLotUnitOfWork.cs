namespace Lab08.ParkingLot.Repository.Interfaces
{
    public interface ILab08ParkingLotUnitOfWork
    {
        IVehicleRepository VehicleRepository { get; }

        void Save();
    }
}