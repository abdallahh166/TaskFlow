using Microsoft.AspNetCore.Mvc;
using TaskFlowBackend.Data;
using TaskFlowBackend.Models;
using System.Linq;

namespace TaskFlowBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == loginRequest.Username);
            if (existingUser == null || existingUser.Password != loginRequest.Password)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var token = JwtHelper.GenerateJwtToken(existingUser.Username, existingUser.UserID);
            var refreshToken = JwtHelper.GenerateRefreshToken();
            return Ok(new { token, refreshToken });
        }
    }
}
