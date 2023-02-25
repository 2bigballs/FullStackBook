using DataAccess.DataSeeds;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(BookSeed.Data());
            modelBuilder.Entity<Rating>().HasData(RatingSeed.Data());
            modelBuilder.Entity<Review>().HasData(ReviewSeed.Data());
        }
    }
}
