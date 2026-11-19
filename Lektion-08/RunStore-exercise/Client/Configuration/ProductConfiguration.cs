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
            // .HasMaxLength(2048)
            .HasColumnType("VARCHAR(2048)");

        builder.Property(c => c.ImageUrl)
            .HasColumnName("imageurl")
            .HasColumnType("VARCHAR(128)");

        builder.Property(c => c.ItemNumber)
            .HasColumnName("itemnumber")
            .HasColumnType("VARCHAR(15)")
            .IsRequired();

        builder.HasIndex(c => c.ItemNumber).IsUnique();

        builder.Property(c => c.Name)
            .HasColumnName("productname")
            .HasMaxLength(80)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(c => c.Price)
            .HasColumnName("price")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.ToTable(c => c.HasCheckConstraint(
            "CK_Product_Price_NonNegative",
            "price >= 0"
        ));
    }
}
