using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartHabitTracker.API.Models
{
    public class Habit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }
        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool? IsCompleted { get; set; }

        public required int UserId { get; set; }
        public User? User { get; set; }

    }
}
