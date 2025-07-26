using Elevator.API.Application.Interfaces;

namespace Elevator.API.Infraestructure.Queues
{
    public class RequestQueue : IRequestQueue
    {
        private readonly List<int> _requests = new();
        private const int MaxFloor = 5;
        private const int MinFloor = 0;

        public void Enqueue(int floor)
        {
            if (floor < MinFloor || floor > MaxFloor)
                throw new ArgumentOutOfRangeException(nameof(floor), $"El piso debe estar entre {MinFloor} y {MaxFloor}.");

            if (!_requests.Contains(floor))
                _requests.Add(floor);
        }

        public List<int> GetRequests() => new(_requests);

        public void Remove(int floor) => _requests.Remove(floor);

        public bool Contains(int floor) => _requests.Contains(floor);

        public bool IsEmpty() => !_requests.Any();
    }
}
