using Microsoft.EntityFrameworkCore;

namespace EFPractice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<Books> Books { get; set; }
    }
}
