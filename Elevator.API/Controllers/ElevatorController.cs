using Elevator.API.Application.Interfaces;
using Elevator.API.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elevator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevatorDoorControl _elevatorDoorControl;
        private readonly IElevatorMovement _elevatorMovement;
        public ElevatorController(IElevatorDoorControl elevatorDoorControl, IElevatorMovement elevatorMovement)
        {
            _elevatorDoorControl = elevatorDoorControl;
            _elevatorMovement = elevatorMovement;
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

        [HttpPost("call")]
        public IActionResult Call([FromBody] int floor)
        {
            _elevatorMovement.CallElevator(floor);
            return Ok();
        }

        [HttpPost("start")]
        public IActionResult Start()
        {
            _elevatorMovement.Start();
            return Ok();
        }

        [HttpPost("stop")]
        public IActionResult Stop()
        {
            _elevatorMovement.Stop();
            return Ok();
        }

        [HttpGet("status")]
        public ActionResult<ElevatorStatus> GetStatus()
        {
            return _elevatorMovement.GetStatus();
        }
    }
}
