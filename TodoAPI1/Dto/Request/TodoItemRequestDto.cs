using TodoAPI1.Model;

namespace TodoAPI1.Dto.Request
{
    public class TodoItemRequestDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public TodoItemRequestDto() { }
        public TodoItemRequestDto(Todo todoItem) => (Id, Name, IsComplete) = (todoItem.Id, todoItem.Name, todoItem.IsComplete);
    }
}
