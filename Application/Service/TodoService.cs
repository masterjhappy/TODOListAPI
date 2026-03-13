using TODOListAPI.Application.Interface;
using TODOListAPI.Models;

namespace TODOListAPI.Application.Service
{
    public class TodoService : ITodoService
    {
        private readonly List<Todo> todoList = new List<Todo>();
        private int nextId = 1;

        public IEnumerable<Todo> GetAll()
        {  
            return todoList; 
        }

        public Todo? GetById(int id) 
        { 
            return todoList.Where(x => x.Id == id).FirstOrDefault(); 
        }

        public Todo Add(Todo item)
        {
            item.Id = nextId++;
            todoList.Add(item);
            return item;
        }
        public bool Update(Todo item)
        {
            Todo? chgItem = todoList.Where(x => x.Id == item.Id).FirstOrDefault();
            if(chgItem != null)
            {
                chgItem.Name = item.Name;
                chgItem.Description = item.Description;
                chgItem.IsDone = item.IsDone;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            return todoList.RemoveAll(x => x.Id == id) > 0;
        }
    }
}
