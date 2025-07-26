using Elevator.API.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elevator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevatorDoorControl _elevatorDoorControl;
        public ElevatorController(IElevatorDoorControl elevatorDoorControl)
        {
            _elevatorDoorControl = elevatorDoorControl;
        }

        [HttpPost("open-doors")]
        public IActionResult OpenDoors()
        {
            _elevatorDoorControl.OpenDoors();
            return Ok();
        }

        [HttpPost("close-doors")]
        public IActionResult CloseDoors()
        {
            _elevatorDoorControl.CloseDoors();
            return Ok();
        }
    }
}
