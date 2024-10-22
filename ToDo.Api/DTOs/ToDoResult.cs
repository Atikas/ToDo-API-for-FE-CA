using ToDo.Api.Models;

namespace ToDo.Api.DTOs
{
    public class ToDoResult : CreateTodoRequest
    {
        public int Id { get; set; }

        public ToDoResult()
        {

        }

        public ToDoResult(ToDoItem item) : base(item)
        {
            Id = item.Id;
        }
    }
}
