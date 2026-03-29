using System.ComponentModel.DataAnnotations;

namespace SmartHabitTracker.API.Models
{
    public class SigninRequest
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
    }
}
