using Microsoft.AspNetCore.Mvc;

namespace Lab08.ParkingLot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        [HttpGet]
        [Route(nameof(GetFreeSpaces))]
        public IActionResult GetFreeSpaces()
        {
            return Ok();
        }

        [HttpGet]
        [Route(nameof(CalculateStayFee))]
        public IActionResult CalculateStayFee()
        {
            return Ok();
        }

        [HttpGet]
        [Route(nameof(VehicleEntrance))]
        public IActionResult VehicleEntrance()
        {
            return Ok();
        }

        [HttpGet]
        [Route(nameof(VehicleExit))]
        public IActionResult VehicleExit()
        {
            return Ok();
        }
    }
}
