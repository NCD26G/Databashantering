using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class PostalCodeConfiguration : IEntityTypeConfiguration<PostalCode>
{
    public void Configure(EntityTypeBuilder<PostalCode> builder)
    {
        builder.ToTable("postalcodes");

        builder.Property(c => c.Id).HasColumnName("id");

        builder.Property(c => c.Code)
            .HasColumnName("postalcode")
            .HasMaxLength(5)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(c => c.CityId).HasColumnName("city_id");

        builder.HasIndex(c => c.Code).IsUnique();

        builder
            .HasMany(c => c.Addresses)
            .WithOne(a => a.PostalCode)
            .HasForeignKey(f => f.PostalCodeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
