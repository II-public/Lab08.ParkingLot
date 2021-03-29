namespace Lab08.ParkingLot.Service.Interfaces
{
    public interface IRegisterService
    {
        int GetFreeSpaces();

        bool VehicleEntrance();

        bool VehicleExit();
    }
}
