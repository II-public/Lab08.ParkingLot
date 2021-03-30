using Lab08.ParkingLot.Enums;
using Lab08.ParkingLot.Model;
using Lab08.ParkingLot.Service.Interfaces;

namespace Lab08.ParkingLot.Service
{
    public class VehicleRatesService : IVehicleRatesService
    {
        public VehicleRatesModel GetRatesByVehicleCategory(VehicleCategory vehicleCategory)
        {
            switch (vehicleCategory)
            {
                case VehicleCategory.A:
                    {
                        return new VehicleRatesModel()
                        {
                            DayLightRates = 3,
                            NightlyRates = 2
                        };
                    }

                case VehicleCategory.B:
                    {
                        return new VehicleRatesModel()
                        {
                            DayLightRates = 6,
                            NightlyRates = 4
                        };
                    }

                case VehicleCategory.C:
                    {
                        return new VehicleRatesModel()
                        {
                            DayLightRates = 12,
                            NightlyRates = 8
                        };
                    }

                default:
                    {
                        return new VehicleRatesModel()
                        {
                            DayLightRates = 3,
                            NightlyRates = 2
                        };
                    }
            }
        }
    }
}
