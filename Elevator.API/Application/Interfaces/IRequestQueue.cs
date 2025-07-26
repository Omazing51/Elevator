namespace Elevator.API.Application.Interfaces
{
    public interface IRequestQueue
    {
        void Enqueue(int floor);
        bool Contains(int floor);
        bool IsEmpty();
        List<int> GetRequests();
        void Remove(int floor);
    }
}
