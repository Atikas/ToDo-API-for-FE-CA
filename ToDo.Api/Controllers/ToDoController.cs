using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using ToDo.Api.Data;
using ToDo.Api.DTOs;
using ToDo.Api.Models;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ToDoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET all to-do items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ToDoResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetToDos()
        {
            var result = await _context.ToDos.Select(t=> new ToDoResult(t)).ToListAsync();
            return Ok(result);
        }

        /// <summary>
        /// GET single to-do item by id
        /// </summary>
        /// <param name="id">id of single todo item</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ToDoResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetToDoItem(int id)
        {
            if (_context.ToDos == null)
                return NotFound(new ErrorResponse("No to do items found"));
            
            var toDoItem = await _context.ToDos.FindAsync(id);
            return toDoItem == null ? NotFound(new ErrorResponse($"No to do items found by id {id}")) : Ok(new ToDoResult(toDoItem));

          
        }

        /// <summary>
        /// UPDATE existing to-do item by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutToDoItem(int id, UpdateTodoRequest req)
        {
            if (id != req.Id)
                return BadRequest(new ErrorResponse("Submitted to do item id doesn't match request id"));

            if (await _context.Users.FindAsync(req.UserId) == null)
                return BadRequest(new ErrorResponse($"No user found by id {req.UserId}"));

            if (req.EndDate.HasValue && req.EndDate.Value < DateTime.Now)
                return BadRequest(new ErrorResponse("End date can not be in past"));

            var item = await _context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

            if (item == null)
                return NotFound(new ErrorResponse($"No to do items found by id {id}"));

            item.UserId = req.UserId;
            item.Type = req.Type;
            item.EndDate = req.EndDate;
            item.Content = req.Content;

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
                {
                    return NotFound(new ErrorResponse($"No to-do items found by id {id}"));
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// CREATE new to-do item
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ToDoResult),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostToDoItem(CreateTodoRequest req)
        {
            if (_context.ToDos == null)
                return StatusCode(500, $"Server error - database issue");

            if (await _context.Users.FindAsync(req.UserId) == null)
                return BadRequest(new ErrorResponse($"No user found by id {req.UserId}"));

            if (req.EndDate.HasValue && req.EndDate.Value < DateTime.Now)
                return BadRequest(new ErrorResponse("End date can not be in past"));

            var toDoEntity = new ToDoItem()
            {
                Content = req.Content,
                EndDate = req.EndDate,
                Type = req.Type,
                UserId = req.UserId
            };
            _context.ToDos.Add(toDoEntity);
            await _context.SaveChangesAsync();

            var createdTodo = new ToDoResult(toDoEntity);

            return CreatedAtAction("GetToDoItem", new { id = createdTodo.Id }, createdTodo);
        }

        /// <summary>
        /// DELETE to-do item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            if (_context.ToDos == null)
                return StatusCode(500, $"Server error - database issue");
            
            var toDoItem = await _context.ToDos.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound(new ErrorResponse($"No to do items found by id {id}"));
            }

            _context.ToDos.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemExists(int id)
        {
            return (_context.ToDos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
