using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
{
    public void Configure(EntityTypeBuilder<SalesOrder> builder)
    {
        builder.ToTable("salesorders");

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.OrderNumber)
            .HasColumnName("ordernumber")
            .HasMaxLength(15)
            .IsUnicode(false)
            .IsRequired();

        builder.HasIndex(c => c.OrderNumber).IsUnique();

        builder.Property(c => c.OrderDate)
            .HasColumnName("orderdate")
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(c => c.CustomerId)
            .HasColumnName("customer_id");
    }
}
