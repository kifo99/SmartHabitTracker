using SmartHabitTracker.API.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartHabitTracker.API.DTOs
{
    public class HabitRequest
    {

        [MaxLength(100)]
        [Required]
        public required string Name { get; set; }
        public bool? IsCompleted { get; set; } = false;

    }
}
