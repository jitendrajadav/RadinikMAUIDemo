using RadinikMAUIDemo.Data;
using RadinikMAUIDemo.Models;

namespace RadinikMAUIDemo.Services
{
    public class TodoService(IUnitOfWork unitOfWork)
    {
        public async Task AddTodoItemAsync(string name)
        {
            var todoItem = new TodoItem { Name = name };
            await unitOfWork.TodoItems.AddAsync(todoItem);
        }

        public async Task<List<TodoItem>> GetAllTodoItemsAsync()
        {
            return [.. (await unitOfWork.TodoItems.GetAllAsync())];
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            var item = await unitOfWork.TodoItems.GetByIdAsync(id);
            if (item != null)
            {
                await unitOfWork.TodoItems.DeleteAsync(item);
            }
        }
    }
}
