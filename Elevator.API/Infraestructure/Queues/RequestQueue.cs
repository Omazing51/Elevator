using Elevator.API.Application.Interfaces;

namespace Elevator.API.Infraestructure.Queues
{
    public class RequestQueue : IRequestQueue
    {
        private readonly Queue<int> _queue = new();
        public int? Dequeue()
        {
            return _queue.Count > 0 ? _queue.Dequeue() : null;
        }
        public void Enqueue(int floor)
        {
            if (!_queue.Contains(floor))
                _queue.Enqueue(floor);
        }
        public bool Contains(int floor) => _queue.Contains(floor);
        public bool IsEmpty() => _queue.Count == 0;
    }
}
