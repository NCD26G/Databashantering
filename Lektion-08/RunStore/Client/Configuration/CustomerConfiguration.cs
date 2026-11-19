using System;
using Client.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.FirstName)
            .HasColumnName("firstname")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.LastName)
            .HasColumnName("lastname")
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(128);

        builder.HasIndex(c => c.Email).IsUnique();

        builder.Property(c => c.Phone)
            .HasColumnName("phone")
            .HasMaxLength(15);

        builder.Property(c => c.AddressId)
            .HasColumnName("address_id");

        builder.HasMany(o => o.SalesOrders)
            .WithOne(c => c.Customer)
            .HasForeignKey(f => f.CustomerId)
            .IsRequired();
    }
}
