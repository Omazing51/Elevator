using Elevator.API.Application.Interfaces;
using Elevator.API.Domain.Enums;
using Elevator.API.Domain.Models;
using Elevator.API.Infraestructure.Queues;

namespace Elevator.API.Application.Services
{
    public class ElevatorService : IElevatorDoorControl, IElevatorMovement
    {
        private readonly IRequestQueue _requestQueue;
        private int _currentFloor = 0;
        private bool _doorsOpen = false;
        private ElevatorState _state = ElevatorState.Idle;

        public ElevatorService(IRequestQueue requestQueue)
        {
            _requestQueue = requestQueue;
        }

        public void CallElevator(int floor)
        {
            _requestQueue.Enqueue(floor);
        }

        public void Start()
        {
            _state = ElevatorState.Moving;
            ProcessRequests();
        }

        public void Stop()
        {
            _state = ElevatorState.Stopped;
        }

        public void OpenDoors() => _doorsOpen = true;

        public void CloseDoors() => _doorsOpen = false;

        public ElevatorStatus GetStatus() => new()
        {
            CurrentFloor = _currentFloor,
            State = _state,
            DoorsOpen = _doorsOpen
        };

        private void ProcessRequests()
        {
            while (!_requestQueue.IsEmpty())
            {
                int? nextFloor = _requestQueue.Dequeue();
                if (nextFloor.HasValue)
                {
                    _currentFloor = nextFloor.Value;
                    OpenDoors();
                    Thread.Sleep(1000); // Simula tiempo de espera
                    CloseDoors();
                }
            }
            _state = ElevatorState.Idle;
        }
    }
}
