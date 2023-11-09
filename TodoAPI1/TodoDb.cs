using Microsoft.EntityFrameworkCore;

namespace TodoAPI1
{
    public class TodoDb
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options)
        { 
        }
        public DbSet<Todo> Todos => DbSet<Todo>(); 
    }
}
