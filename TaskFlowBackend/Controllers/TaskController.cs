using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlowBackend.Data;
using TaskFlowBackend.Models;
using System.Linq;
using System.Security.Claims;

namespace TaskFlowBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/task/tasks
        [HttpGet("tasks")]
        public IActionResult GetTasks()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); // Get the logged-in user's ID from the claim
            var tasks = _context.Tasks.Where(t => t.UserID == userId).ToList();
            return Ok(tasks);

        }

        // POST: api/task/create
        [HttpPost("create")]
        public IActionResult CreateTask([FromBody] TaskModel task)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); // Get the logged-in user's ID from the claim
            task.UserID = userId;

            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(new { message = "Task created successfully" });
        }
    }
}
