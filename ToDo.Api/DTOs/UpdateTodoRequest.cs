namespace ToDo.Api.DTOs
{
    public class UpdateTodoRequest : CreateTodoRequest
    {
        /// <summary>
        /// Id of todo item. Must be the as provided in path.
        /// </summary>
        public int Id { get; set; }
    }
}
