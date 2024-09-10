using Microsoft.EntityFrameworkCore;

namespace WebAPIUserManagement.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }

    }
}
