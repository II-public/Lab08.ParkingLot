using Lab08.ParkingLot.Enums;
using Lab08.ParkingLot.Model;

namespace Lab08.ParkingLot.Service.Interfaces
{
    public interface IVehicleRatesService
    {
        VehicleRatesModel GetRatesByVehicleCategory(VehicleCategory vehicleCategory);
    }
}
