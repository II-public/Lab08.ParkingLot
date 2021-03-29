using System.Collections.Generic;
using Lab08.ParkingLot.Enums;
using Lab08.ParkingLot.Service.Interfaces;

namespace Lab08.ParkingLot.Service.Calculators
{
    public class CalculatorFactory : ICalculatorFactory
    {
        private readonly Dictionary<VehicleCategory, IVehicleCalculator> _calculators;

        public CalculatorFactory()
        {
            _calculators = new Dictionary<VehicleCategory, IVehicleCalculator>
            {
                { VehicleCategory.A, new VehicleCalculatorCatA() },
                { VehicleCategory.B, new VehicleCalculatorCatB() },
                { VehicleCategory.C, new VehicleCalculatorCatC() },
            };
        }

        public IVehicleCalculator GetVehicleCalculator(VehicleCategory vehicleCategory)
        {
            return _calculators[vehicleCategory];
        }
    }
}
