using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHabitTracker.API.Data;
using SmartHabitTracker.API.Models;
using BCrypt.Net;

namespace SmartHabitTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AuthController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            
            if(existingUser != null)
            {
                return BadRequest("User already exists!");
            }

            if(request.Password != request.ConfirmPassword)
            {
                return BadRequest("Password do not match");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                HashedPassword = hashedPassword
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] SigninRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null) return BadRequest("User not found");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.HashedPassword)) {
                return BadRequest("Wrong password");
            }

            string token = Jwt

            return Ok(new { message = "Login successfull" });
        }

    }
}
