using TodoAPI1.Repository;

namespace TodoAPI1.Services
{
    public class TodoService
    {
        private TodoRepository _todoRepository;

        public TodoService(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

    }
}
