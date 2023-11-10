using TodoAPI1.Model;

namespace TodoAPI1.Repository
{
    public class TodoRepository
    {
        private readonly TodoDb _context;

        public TodoRepository(TodoDb context)
        {
            _context = context;
        }

        public async void Salvar(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
        }
    }
}
