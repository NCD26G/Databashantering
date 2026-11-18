using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Client.Entities;

namespace Client.Data;

public class RunStoreDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("<Your connectionString here!>");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Supplier>()
                    .HasData(
                        new Supplier
                        {
                            Id = 1,
                            Name = "Asics"
                        }, new Supplier
                        {
                            Id = 2,
                            Name = "Nike"
                        }
                        , new Supplier
                        {
                            Id = 3,
                            Name = "CLN Athletics"
                        }, new Supplier
                        {
                            Id = 4,
                            Name = "Swix"
                        }
                    );

        modelBuilder.Entity<Product>().HasData(
            new
            {
                Id = 1,
                ItemNumber = "1000",
                Name = "Core 2000",
                ImageUrl = "https://res.cloudinary.com/softtech-dev/image/upload/v1786556514/shoe-1_qig4ut.jpg",
                Description = "Lorem ipsum dolor sit amet",
                Price = 1295,
                SupplierId = 1
            },
            new
            {
                Id = 2,
                ItemNumber = "1001",
                Name = "Gel 27",
                ImageUrl = "https://res.cloudinary.com/softtech-dev/image/upload/v1786556530/shoe-3_qbzcwy.jpg",
                Description = "Lorem ipsum dolor sit amet",
                Price = 2295,
                SupplierId = 2
            }
        );


    }
}
