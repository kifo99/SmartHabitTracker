using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHabitTracker.API.Data;
using SmartHabitTracker.API.DTOs;
using SmartHabitTracker.API.Models;

namespace SmartHabitTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitController : ControllerBase
    {

        private readonly DatabaseContext _context;


        public HabitController(DatabaseContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost("add/{userId}")]
        public async Task<IActionResult> CreateHabit(HabitRequest request, int userId)
        {

            var user = await _context.Users.FindAsync(userId);

            if (user == null) { return BadRequest("User not found"); }

            var habitExists = await _context.Habits.FirstOrDefaultAsync(u => u.Name == request.Name);


            if (habitExists != null) { return BadRequest("Habit already exists"); }

            var habit = new Habit
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
                UserId = userId,
                User = user,
            };

            _context.Habits.Add(habit);
            _context.SaveChanges();


            return Ok(new
            {
                message = "Habit added successfuly"
            });
        }

        [Authorize]
        [HttpPut("edit/{habitId}")]
        public async Task<IActionResult> EditHabit(HabitRequest request, int habitId)
        {
            var habit = await _context.Habits.FindAsync(habitId);

            if (habit == null) { return BadRequest("Habit was not found"); }

            habit.Name = request.Name;
            habit.IsCompleted = request.IsCompleted;

            _context.Habits.Update(habit); _context.SaveChanges();

            return Ok(new { message = "Habit is edited successfuly" });
        }

        [Authorize]
        [HttpDelete("delete/{habitId}")]
        public async Task<IActionResult> DeleteHabit(int habitId)
        {
            var habit = await _context.Habits.FindAsync(habitId);

            if (habit == null) { return BadRequest("Habit was not found"); }

            _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Habit deleted successfuly" });
        }
    }
}
