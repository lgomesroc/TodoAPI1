using TodoAPI1.Dto.Response;

namespace TodoAPI1.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }

        public Todo(TodoItemResponseDto todoItem) => (Id, Name, IsComplete) = (todoItem.Id, todoItem.Name, todoItem.IsComplete);
    }
}
