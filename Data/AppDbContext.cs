using BookManagementProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Genres)
                .WithMany(x => x.Books); 

        }
    }
}
