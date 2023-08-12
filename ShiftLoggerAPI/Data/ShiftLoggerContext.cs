using Microsoft.EntityFrameworkCore;
using ShiftLoggerAPI.Models;

namespace ShiftLoggerAPI.Data
{
    public class ShiftLoggerContext : DbContext
    {
        //public ShiftLoggerContext(DbContextOptions<ShiftLoggerContext> options) : base(options) { }
        public DbSet<Shift> Shifts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ShiftLoggerDB;Database=ShiftLogger;Trusted_Connection=True");
        }
    }
}
    