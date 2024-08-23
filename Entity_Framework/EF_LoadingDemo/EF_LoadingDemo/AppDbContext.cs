using EF_LoadingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_LoadingDemo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Villa> Villas {  get; set; }
        public DbSet<VillaEminity> VillaEminity { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id =1,
                    Name = "Royal Villa",
                    price = 200
                },
                new Villa
                {
                    Id = 2,
                    Name = "Premium Pool Villa",
                    price = 300
                },
                new Villa
                {
                    Id = 3,
                    Name = "Luxury Pool Villa",
                    price= 500
                }
            );

            modelBuilder.Entity<VillaEminity>().HasData(
                new VillaEminity
                {
                    Id = 1,
                    VillaId = 1,
                    name = "private pool",
                },
                new VillaEminity
                {
                    Id = 2,
                    VillaId = 1,
                    name = "microwave",
                },
                new VillaEminity
                {
                    Id = 3,
                    VillaId = 1,
                    name = "private balcony",
                },
                new VillaEminity
                {
                    Id = 4,
                    VillaId = 2,
                    name = "1 king size bed",
                },
                new VillaEminity
                {
                    Id = 5,
                    VillaId = 2,
                    name = "pool",
                },
                new VillaEminity
                {
                    Id = 6,
                    VillaId = 3,
                    name = "food + Bed",
                }
            );
        }
    }
}
