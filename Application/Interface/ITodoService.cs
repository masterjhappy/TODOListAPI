using TODOListAPI.Models;

namespace TODOListAPI.Application.Interface
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAll();
        Todo? GetById(int id);
        Todo Add(Todo item);
        bool Update(Todo item);
        bool Delete(int id);
    }
}
