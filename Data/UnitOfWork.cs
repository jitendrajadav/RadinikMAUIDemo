using RadinikMAUIDemo.Data;
using RadinikMAUIDemo.Db;
using RadinikMAUIDemo.Models;

namespace RadinikMAUIDemo.Comman
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LocalDatabase _context;

        public IRepository<TodoItem> TodoItems { get; private set; }

        public UnitOfWork(LocalDatabase context)
        {
            _context = context;
            TodoItems = new Repository<TodoItem>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
