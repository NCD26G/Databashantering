using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItems>
{
    public void Configure(EntityTypeBuilder<OrderItems> builder)
    {
        builder.ToTable("orderitems");
        builder
            .Property(oi => oi.SalesOrderId)
            .HasColumnName("order_id");

        builder
            .Property(oi => oi.ProductId)
            .HasColumnName("product_id");

        builder
            .Property(oi => oi.Discount)
            .HasColumnName("discount");

        builder
        .Property(oi => oi.Price)
        .HasColumnName("price");

        builder
            .Property(oi => oi.Quantity)
            .HasColumnName("quantity");

        builder.HasKey(oi => new { oi.SalesOrderId, oi.ProductId });
        builder.HasOne(oi => oi.SalesOrder)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
