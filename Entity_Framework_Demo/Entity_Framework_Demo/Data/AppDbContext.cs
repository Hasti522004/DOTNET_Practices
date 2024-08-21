using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Demo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .HasOne(b => b.Language)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LanguageId);

            modelBuilder.Entity<BookPrice>()
                .HasOne(bp => bp.Book)
                .WithMany(b => b.BookPrices)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookPrice>()
                .HasOne(bp => bp.Currency)
                .WithMany(b => b.BookPrices)
                .HasForeignKey(b => b.CurrencyId);

            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title = "INR", Description = "Indian INR" },
                new Currency() { Id = 2, Title = "Doller", Description = "Doller" },
                new Currency() { Id = 3, Title = "Euro", Description = "Euro" },
                new Currency() { Id = 4, Title = "Dinar", Description = "Dinar" }
            );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "Hindi", Description = "Mumbai" },
                new Language() { Id = 2, Title = "Gujrati", Description = "Gujrat" },
                new Language() { Id = 3, Title = "English", Description = "USA" },
                new Language() { Id = 4, Title = "Tamil", Description = "Tamilnadu" },
                new Language() { Id = 5, Title = "Urdu", Description = "Iran" }
            );
        }
      

        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currencys { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
