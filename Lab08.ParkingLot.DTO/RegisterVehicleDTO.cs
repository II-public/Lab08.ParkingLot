using Lab08.ParkingLot.Enums;

namespace Lab08.ParkingLot.DTO
{
    public class RegisterVehicleDTO
    {
        public string VehicleNumber { get; set; }

        public VehicleCategory VehicleCategory { get; set; }
    }
}
