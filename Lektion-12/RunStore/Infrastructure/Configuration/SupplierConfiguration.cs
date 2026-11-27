using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
                builder.ToTable("suppliers");

                builder.Property(p => p.Name)
                        .HasColumnName("suppliername")
                        .HasMaxLength(80)
                        .IsUnicode(false)
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

                builder
                        .HasMany(a => a.Addresses)
                        .WithMany(s => s.Suppliers)
                        .UsingEntity("supplieraddresses",
                        r => r.HasOne(typeof(Address)).WithMany().HasForeignKey("address_id").OnDelete(DeleteBehavior.Restrict),
                        l => l.HasOne(typeof(Supplier)).WithMany().HasForeignKey("supplier_id").OnDelete(DeleteBehavior.Restrict)
                        );
        }
}
