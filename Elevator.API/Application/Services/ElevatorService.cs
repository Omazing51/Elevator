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

            if (_state == ElevatorState.Idle)
            {
                Start();
            }
        }

        public void Start()
        {
            if (_doorsOpen)
            {
                CloseDoors();
            }

            _state = ElevatorState.Moving;
            ProcessRequests();
        }

        public void Stop()
        {
            _state = ElevatorState.Stopped;
        }

        public void OpenDoors()
        {
            _doorsOpen = true;

            Task.Run(async () =>
            {
                await Task.Delay(2000); 
                _doorsOpen = false;
            });
        }

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
                var requests = _requestQueue.GetRequests();

                requests.Sort((a, b) => a.CompareTo(b));

                foreach (var targetFloor in requests)
                {
                    while (_currentFloor != targetFloor && _state == ElevatorState.Moving)
                    {
                        _currentFloor += _currentFloor < targetFloor ? 1 : -1;
                        Thread.Sleep(3000); 
                    }

                    if (_currentFloor == targetFloor)
                    {
                        OpenDoors();
                        Thread.Sleep(3000); 
                        CloseDoors();
                        _requestQueue.Remove(targetFloor); 
                    }
                }
            }

            _state = ElevatorState.Idle;
        }
    }
}
