using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI1.Dto.Response;
using TodoAPI1.Model;
using TodoAPI1.Services;

namespace TodoAPI1.Controller
{
    public class TodoController : ControllerBase
    {
        //Contructor
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }


        [HttpGet()]
        public async Task<IResult> GetAllTodos(TodoDb db)
        {
            return TypedResults.Ok(await db.Todos.Select(x => new TodoItemResponseDto(x)).ToArrayAsync());
        }

        [HttpGet("/complete")]
        public async Task<IResult> GetCompleteTodos(TodoDb db)
        {
            return TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).Select(x => new TodoItemResponseDto(x)).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetTodo(int id, TodoDb db)
        {
            return await db.Todos.FindAsync(id)
                is Todo todo
                    ? TypedResults.Ok(new TodoItemResponseDto(todo))
                    : TypedResults.NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CreateTodo(TodoItemResponseDto todoItemDTO)
        {
            try
            {
                Todo todoItem = new Todo(todoItemDTO);

                await _todoService.AddTodo(todoItem);

                todoItemDTO = new TodoItemResponseDto(todoItem);

                return Ok("Todo created success");

            }
            catch (Exception)
            {

                throw;
            }
        }

        static async Task<IResult> UpdateTodo(int id, TodoItemResponseDto todoItemDTO, TodoDb db)
        {
            var todo = await db.Todos.FindAsync(id);

            if (todo is null) return TypedResults.NotFound();

            todo.Name = todoItemDTO.Name;
            todo.IsComplete = todoItemDTO.IsComplete;

            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        static async Task<IResult> DeleteTodo(int id, TodoDb db)
        {
            if (await db.Todos.FindAsync(id) is Todo todo)
            {
                db.Todos.Remove(todo);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
        }
    }
}
