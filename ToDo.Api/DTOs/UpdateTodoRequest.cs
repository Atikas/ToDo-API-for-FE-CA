namespace ToDo.Api.DTOs
{
    public class UpdateTodoRequest : CreateTodoRequest
    {
        /// <summary>
        /// Id of to-do item. Must be the as provided in path.
        /// </summary>
        public int Id { get; set; }
    }
}
