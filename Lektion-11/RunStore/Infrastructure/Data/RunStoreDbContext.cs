using Core.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class RunStoreDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SalesOrder> SalesOrders { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<AddressType> AddressTypes { get; set; }
    public DbSet<PostalCode> PostalCodes { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceType> InvoiceTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new SalesOrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemsConfiguration());
        modelBuilder.ApplyConfiguration(new PostalCodeConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
    }
}
