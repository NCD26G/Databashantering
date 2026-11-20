using Client.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configuration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("suppliers");

        builder.Property(p => p.Name)
                .HasColumnName("suppliername")
                .HasColumnType("VARCHAR(80)")
                .IsRequired();

        builder.Property(p => p.Id)
                .HasColumnName("id");

        builder.HasIndex(n => n.Name).IsUnique();

        builder
            .HasMany(c => c.Products)
            .WithOne(s => s.Supplier)
            .HasForeignKey(f => f.SupplierId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
