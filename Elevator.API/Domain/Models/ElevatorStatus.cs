using Elevator.API.Domain.Enums;

namespace Elevator.API.Domain.Models
{
    public class ElevatorStatus
    {
        public int CurrentFloor { get; set; }
        public ElevatorState State { get; set; }
        public bool DoorsOpen { get; set; }
    }
}
