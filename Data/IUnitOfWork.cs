using RadinikMAUIDemo.Models;

namespace RadinikMAUIDemo.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TodoItem> TodoItems { get; }
        Task<int> CompleteAsync();
    }
}
