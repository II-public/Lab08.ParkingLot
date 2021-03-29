using Lab08.ParkingLot.Enums;

namespace Lab08.ParkingLot.Service.Interfaces
{
    public interface ICalculatorFactory
    {
        IVehicleCalculator GetVehicleCalculator(VehicleCategory vehicleCategory);
    }
}
