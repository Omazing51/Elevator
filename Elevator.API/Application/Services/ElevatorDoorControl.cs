using Elevator.API.Application.Interfaces;

namespace Elevator.API.Application.Services
{
    public class ElevatorDoorControl : IElevatorDoorControl
    {
        private bool _doorsOpen = false;
        public void CloseDoors()
        {
            _doorsOpen = false;
        }

        public void OpenDoors()
        {
            _doorsOpen = true;
        }
    }
}
