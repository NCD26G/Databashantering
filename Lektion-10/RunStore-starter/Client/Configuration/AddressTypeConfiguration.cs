using Client.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configuration;

public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
{
    public void Configure(EntityTypeBuilder<AddressType> builder)
    {
        builder.ToTable("addresstypes");
        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.AddressTypeName)
            .HasColumnName("addresstype")
            .HasMaxLength(40)
            .IsRequired()
            .IsUnicode(false);
    }
}
