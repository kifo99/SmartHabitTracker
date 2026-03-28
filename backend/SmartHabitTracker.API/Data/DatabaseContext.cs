using Microsoft.EntityFrameworkCore;
using SmartHabitTracker.API.Models;
using System.Security.Cryptography.X509Certificates;

namespace SmartHabitTracker.API.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
    }
    
}
