using System.ComponentModel.DataAnnotations;
using ToDo.Api.Models;

namespace ToDo.Api.DTOs;

public class CreateTodoRequest
{
    /// <summary>
    /// User id of user who created to-do item. Id can be resieved by fetching api/Auth method.
    /// User id should already exist in database.
    /// </summary>
    [Required]
    public string UserId { get; set; }

    /// <summary>
    /// Type of to-do item. Can be any string.
    /// Recomended values: "Work", "Home", "Personal"
    /// </summary>
    [Required]
    public string Type { get; set; }

    /// <summary>
    /// Content of to-do item. Can be any string.
    /// </summary>
    [Required]
    public string Content { get; set; }

    /// <summary>
    /// End date of to-do item. Can be null.
    /// Can not be in past.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Is to-do item done. Default is false.
    /// </summary>
    public bool IsDone { get; set; } = false;

    /// <summary>
    /// Priority of to-do item. Default is 1.
    /// A higher number means higher priority.
    /// Allowed values:  1, 2, 3, 4, 5
    /// </summary>
    [Range(1, 5)]
    public int Priority { get; set; } = 1;

    public CreateTodoRequest()
    {

    }

    public CreateTodoRequest(ToDoItem item)
    {
        UserId = item.UserId;
        Type = item.Type;
        Content = item.Content;
        EndDate = item.EndDate;
        IsDone = item.IsDone;
        Priority = item.Priority;
    }

    public static explicit operator ToDoItem(CreateTodoRequest req)
    {
        return new ToDoItem()
        {
            UserId = req.UserId,
            Type = req.Type,
            Content = req.Content,
            EndDate = req.EndDate,
            IsDone = req.IsDone,
            Priority = req.Priority
        };
    }
}
