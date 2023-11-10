using Microsoft.EntityFrameworkCore;
using TodoAPI1.Model;

namespace TodoAPI1
{
    //Heritage (DbContext)

    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options)
        { 
            
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
