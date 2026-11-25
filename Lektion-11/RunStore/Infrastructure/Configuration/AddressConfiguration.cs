using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("addresses");
        builder.Property(a => a.Id).HasColumnName("id");
        builder.Property(a => a.AddressTypeId).HasColumnName("addresstype_id");
        builder.Property(a => a.AddressLine).HasColumnName("addressline").HasMaxLength(80).IsUnicode(false).IsRequired();
        builder.Property(a => a.PostalCodeId).HasColumnName("postalcode_id");

        builder.HasOne(at => at.AddressType)
            .WithMany(a => a.Addresses)
            .HasForeignKey(at => at.AddressTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
