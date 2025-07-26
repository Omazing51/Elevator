using Elevator.API.Application.Interfaces;

namespace Elevator.API.Infraestructure.Queues
{
    public class RequestQueue : IRequestQueue
    {
        private readonly Queue<int> _queue = new();
        private const int MaxFloor = 5;
        private const int MinFloor = 0;

        public void Enqueue(int floor)
        {
            if (floor < MinFloor || floor > MaxFloor)
                throw new ArgumentOutOfRangeException(nameof(floor), $"El piso debe estar entre {MinFloor} y {MaxFloor}.");

            if (!_queue.Contains(floor))
                _queue.Enqueue(floor);
        }

        public int? Dequeue()
        {
            return _queue.Count > 0 ? _queue.Dequeue() : null;
        }

        public bool Contains(int floor) => _queue.Contains(floor);

        public bool IsEmpty() => _queue.Count == 0;
    }
}
