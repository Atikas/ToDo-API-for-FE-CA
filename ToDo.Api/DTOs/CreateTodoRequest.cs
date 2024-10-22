using ToDo.Api.Models;

namespace ToDo.Api.DTOs
{
    public class CreateTodoRequest
    {
        /// <summary>
        /// User id of user who created todo item. Id can be resieved by fetching api/Auth method.
        /// User id should already exist in database.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Type of todo item. Can be any string.
        /// Recomended values: "Work", "Home", "Personal"
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Content of todo item. Can be any string.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// End date of todo item. Can be null.
        /// Can not be in past.
        /// </summary>
        public DateTime? EndDate { get; set; }

        public CreateTodoRequest()
        {

        }

        public CreateTodoRequest(ToDoItem item)
        {
            UserId = item.UserId;
            Type = item.Type;
            Content = item.Content;
            EndDate = item.EndDate;
        }
    }
}
