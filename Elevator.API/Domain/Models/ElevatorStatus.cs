namespace Elevator.API.Domain.Models
{
    public class ElevatorStatus
    {
        public int CurrentFloor { get; set; }
        public string State { get; set; }
        public bool DoorsOpen { get; set; }
    }
}
