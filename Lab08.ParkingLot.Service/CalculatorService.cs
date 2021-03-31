using System;
using System.Linq;
using Lab08.ParkingLot.Data.DataBase;
using Lab08.ParkingLot.DTO;
using Lab08.ParkingLot.Enums;
using Lab08.ParkingLot.Model;
using Lab08.ParkingLot.Repository.Interfaces;
using Lab08.ParkingLot.Service.Interfaces;

namespace Lab08.ParkingLot.Service
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ILab08ParkingLotUnitOfWork _lab08ParkingLotUnitOfWork;
        private readonly IVehicleRatesService _vehicleRatesService;

        public CalculatorService(
            ILab08ParkingLotUnitOfWork lab08ParkingLotUnitOfWork,
            IVehicleRatesService vehicleRatesService)
        {
            _lab08ParkingLotUnitOfWork = lab08ParkingLotUnitOfWork;
            _vehicleRatesService = vehicleRatesService;
        }

        public VehicleCalculationResultModel CalculateFee(VehicleFeeCalculationDTO vehicleFeeCalculationDTO)
        {
            Vehicle vehicle =
                _lab08ParkingLotUnitOfWork.VehicleRepository.GetAll().FirstOrDefault(v => v.Number == vehicleFeeCalculationDTO.VehicleNumber);

            if (vehicle == null)
            {
                return new VehicleCalculationResultModel()
                {
                    Fee = 0,
                    Message = "Vehicle not found!"
                };
            }

            VehicleRatesModel rates = _vehicleRatesService.GetRatesByVehicleCategory(vehicle.VehicleCategory);

            int result = 0;

            double totalDays = (vehicleFeeCalculationDTO.CheckTime - vehicle.EntryTime).TotalDays;
            int wholeDays = (int)Math.Truncate(totalDays);

            if (wholeDays > 0)
            {
                result = wholeDays * 12 * rates.DayLightRates + wholeDays * 12 * rates.NightlyRates;

                DateTime reminder = vehicleFeeCalculationDTO.CheckTime.AddDays(wholeDays);

                result = result + CalculateWhenStayTimeIsLessThanADay(reminder, vehicleFeeCalculationDTO.CheckTime, rates);
            }
            else
            {
                result = CalculateWhenStayTimeIsLessThanADay(vehicle.EntryTime, vehicleFeeCalculationDTO.CheckTime, rates);
            }

            return new VehicleCalculationResultModel()
            {
                Fee = ApplyDiscount(result, vehicle.DiscountCard),
                Message = "Vehicle fee calculated."
            }; ;
        }

        private int CalculateWhenStayTimeIsLessThanADay(DateTime startDate, DateTime endDate, VehicleRatesModel rates)
        {
            int result = 0;
            var daylyRatesStart = new DateTime(endDate.Year, endDate.Month, endDate.Day, 8, 0, 0);
            var daylyRatesEnd = new DateTime(endDate.Year, endDate.Month, endDate.Day, 18, 0, 0);

            if (startDate < daylyRatesStart)
            {
                int calculatedHours = (int)Math.Round((daylyRatesStart - startDate).TotalHours + 0.5);
                result = calculatedHours * rates.NightlyRates;

                startDate = startDate.AddHours(calculatedHours);
            }

            if (endDate < daylyRatesEnd)
            {
                result += (int)Math.Round((endDate - startDate).TotalHours + 0.5) * rates.DayLightRates;
            }
            else
            {
                result += (int)Math.Round((daylyRatesEnd - startDate).TotalHours + 0.5) * rates.DayLightRates +
                            (int)Math.Round((endDate - daylyRatesEnd).TotalHours - 1 + 0.5) * rates.NightlyRates;
            }


            return result;
        }

        private double ApplyDiscount(int calculatedFee, DiscountCard discountCard)
        {
            int percentageDiscount = _vehicleRatesService.GetDiscountByDiscountCardType(discountCard);

            double calculatedFeeWithDiscount = calculatedFee - (calculatedFee * percentageDiscount) / (double)100;

            return Math.Truncate(calculatedFeeWithDiscount * 100) / 100;
        }
    }
}
