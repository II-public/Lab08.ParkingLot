using Lab08.ParkingLot.DTO;
using Lab08.ParkingLot.Model;

namespace Lab08.ParkingLot.Service.Interfaces
{
    public interface ICalculatorService
    {
        VehicleCalculationResultModel CalculateFee(VehicleFeeCalculationDTO vehicleFeeCalculationDTO);
    }
}
