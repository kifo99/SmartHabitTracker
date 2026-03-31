using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHabitTracker.API.Data;
using SmartHabitTracker.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SmartHabitTracker.API.DTOs;

namespace SmartHabitTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        public AuthController(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // /api/Auth/signup/
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
            {
                return BadRequest("User already exists!");
            }

            if (request.Password != request.ConfirmPassword)
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

        // /api/Auth/signin
        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] SigninRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null) return BadRequest("User not found");

            var jwtConfig = _configuration.GetSection("Jwt");

            var key = jwtConfig["Key"] ?? throw new Exception("JWT key missing");
            var issuer = jwtConfig["Issuer"] ?? throw new Exception("JWT issuer missing");
            var audience = jwtConfig["Audience"] ?? throw new Exception("JWT audience missing");
            var issuerSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(issuerSignKey, SecurityAlgorithms.HmacSha256);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.HashedPassword))
            {
                return BadRequest("Wrong password");
            }

            const int _tokenLifetime = 10; //minutes

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, request.Email)
            };

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_tokenLifetime),
                signingCredentials: creds
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwt),
                expires = _tokenLifetime * 60,
                message = "Login successfull"
            });

        }
    }
}
