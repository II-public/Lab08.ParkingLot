using Lab08.ParkingLot.DTO;
using Lab08.ParkingLot.Model;

namespace Lab08.ParkingLot.Service.Interfaces
{
    public interface IRegisterService
    {
        int GetFreeSpaces();

        VehicleEntranceResultModel VehicleEntrance(RegisterVehicleDTO registerVehicleDTO);

        VehicleExitResultModel VehicleExit(ExitVehicleDTO exitVehicleDTO);
    }
}
