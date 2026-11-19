using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Client.Entities;
using Client.Configuration;

namespace Client.Data;

public class RunStoreDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SalesOrder> SalesOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=runstoredb;User Id=postgres;Password=postgres");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent Api
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new SalesOrderConfiguration());

        // Konfigurera Address klassen
        modelBuilder.Entity<Address>().ToTable("addresses");

        modelBuilder.Entity<Address>()
            .Property(a => a.Id).HasColumnName("id");

        modelBuilder.Entity<Address>()
            .Property(a => a.AddressLine)
            .HasColumnName("addressline");

        modelBuilder.Entity<Address>()
            .Property(a => a.CustomerId)
            .HasColumnName("customer_id");

        // Konfigurera många-till-många relationen mellan Address och Customer
        modelBuilder.Entity<Customer>()
            .HasMany(a => a.Addresses)
            .WithMany(c => c.Customers)
            .UsingEntity("customeraddresses",
                // Till höger har vi en tabell/klass Address som kommer att ha många adress id i tabellen customeraddresses 
                r => r.HasOne(typeof(Address)).WithMany().HasForeignKey("address_id").OnDelete(DeleteBehavior.Restrict),
                // Till vänster har vi en tabell/klass Customer som kommer att ha många kund id i tabellen customeraddresses
                l => l.HasOne(typeof(Customer)).WithMany().HasForeignKey("customer_id").OnDelete(DeleteBehavior.Restrict)
            );

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
                Price = 1295M,
                SupplierId = 1
            },
            new
            {
                Id = 2,
                ItemNumber = "1001",
                Name = "Gel 27",
                ImageUrl = "https://res.cloudinary.com/softtech-dev/image/upload/v1786556530/shoe-3_qbzcwy.jpg",
                Description = "Lorem ipsum dolor sit amet",
                Price = 2295M,
                SupplierId = 2
            }
        );


    }
}
