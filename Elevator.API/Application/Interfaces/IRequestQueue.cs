namespace Elevator.API.Application.Interfaces
{
    public interface IRequestQueue
    {
        void Enqueue(int floor);
        int? Dequeue();
        bool Contains(int floor);
        bool IsEmpty();
    }
}
