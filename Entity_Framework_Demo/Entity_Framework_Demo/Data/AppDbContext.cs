using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Demo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
