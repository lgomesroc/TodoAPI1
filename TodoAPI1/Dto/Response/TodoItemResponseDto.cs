using TodoAPI1.Model;

namespace TodoAPI1.Dto.Response
{
    public class TodoItemResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public TodoItemResponseDto() { }


        public TodoItemResponseDto(Todo todoItem) => (Id, Name, IsComplete) = (todoItem.Id, todoItem.Name, todoItem.IsComplete);



    }
}
