// Controllers/AccountController.cs
using Microsoft.AspNetCore.Mvc;
using TaskFlowBackend.Data;
using TaskFlowBackend.Models;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("signup")]
    public IActionResult SignUp([FromBody] User user)
    {
        // Validate input
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Email))
        {
            return BadRequest("All fields are required.");
        }

        // Check if the user already exists
        if (_context.Users.Any(u => u.Username == user.Username))
        {
            return BadRequest("User already exists.");
        }

        // Add the new user to the database
        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok("User registered successfully.");
    }
}