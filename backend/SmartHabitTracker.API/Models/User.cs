using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHabitTracker.API.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [MaxLength(45)]
        public required string Username { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string HashedPassword { get; set; }
         
        public List<Habit>? Habits { get; set; } = new List<Habit>();
    }
}
