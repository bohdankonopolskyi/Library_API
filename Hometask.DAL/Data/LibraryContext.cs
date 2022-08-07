
using Hometask.DAL.Configuration;
using Hometask.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Hometask.DAL.Data;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        Seed(modelBuilder);
    }

    private void Seed(ModelBuilder builder)
    {
        builder.Entity<Book>()
            .HasData(
                new Book() {Id = 1, Author = "Arthur"}
                );
        
        builder.Entity<Review>()
            .HasData(
                new Review() {Id = 1}
                );

        builder.Entity<Rating>()
            .HasData(
                new Rating(){Id = 1}
                );
    }
}