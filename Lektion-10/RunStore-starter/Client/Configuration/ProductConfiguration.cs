using Client.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.Description)
            .HasColumnName("description")
            .HasMaxLength(2048)
            .IsUnicode(false);

        builder.Property(c => c.ImageUrl)
            .HasColumnName("imageurl")
            .HasMaxLength(128)
            .IsUnicode(false);

        builder.Property(c => c.ItemNumber)
            .HasColumnName("itemnumber")
            .HasMaxLength(15)
            .IsUnicode(false)
            .IsRequired();

        builder.HasIndex(c => c.ItemNumber).IsUnique();

        builder.Property(c => c.Name)
            .HasColumnName("productname")
            .HasMaxLength(80)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(c => c.Price)
            .HasColumnName("price")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(c => c.SupplierId).HasColumnName("supplier_id");

        builder.ToTable(c => c.HasCheckConstraint(
            "CK_Product_Price_NonNegative",
            "price >= 0"
        ));
    }
}
