using Elevator.API.Domain.Models;

namespace Elevator.API.Application.Interfaces
{
    public interface IElevatorMovement
    {
        void CallElevator(int floor);
        void Start();
        void Stop();
        ElevatorStatus GetStatus();
    }
}
