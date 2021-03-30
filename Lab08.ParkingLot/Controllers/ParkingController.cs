using Lab08.ParkingLot.DTO;
using Lab08.ParkingLot.Model;
using Lab08.ParkingLot.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08.ParkingLot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ICalculatorService _calculatorService;

        public ParkingController(
            IRegisterService registerService,
            ICalculatorService calculatorService)
        {
            _registerService = registerService;
            _calculatorService = calculatorService;
        }

        [HttpGet]
        [Route(nameof(GetFreeSpaces))]
        public int GetFreeSpaces() => _registerService.GetFreeSpaces();

        [HttpGet]
        [Route(nameof(CalculateStayFee))]
        public VehicleCalculationResultModel CalculateStayFee(VehicleFeeCalculationDTO vehicleFeeCalculationDTO)
        {
            VehicleCalculationResultModel result = _calculatorService.CalculateFee(vehicleFeeCalculationDTO);
            return result;
        }

        [HttpGet]
        [Route(nameof(VehicleEntrance))]
        public VehicleEntranceResultModel VehicleEntrance(RegisterVehicleDTO registerVehicleDTO)
        {
            VehicleEntranceResultModel result = _registerService.VehicleEntrance(registerVehicleDTO);
            return result;
        }

        [HttpGet]
        [Route(nameof(VehicleExit))]
        public IActionResult VehicleExit()
        {
            return Ok();
        }
    }
}
