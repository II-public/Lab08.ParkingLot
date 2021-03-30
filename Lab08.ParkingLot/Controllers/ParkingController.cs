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

        public ParkingController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet]
        [Route(nameof(GetFreeSpaces))]
        public int GetFreeSpaces() => _registerService.GetFreeSpaces();

        [HttpGet]
        [Route(nameof(CalculateStayFee))]
        public IActionResult CalculateStayFee()
        {
            return Ok();
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
