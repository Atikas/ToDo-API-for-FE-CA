using Microsoft.AspNetCore.Identity;

namespace ToDo.Api.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDone { get; set; } = false;
        public int Priority { get; set; }
        public string UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
