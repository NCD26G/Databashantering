using System;
using Client.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        // Konfigurera Address klassen
        builder.ToTable("addresses");
        builder.Property(a => a.Id).HasColumnName("id");
        builder.Property(a => a.AddressLine).HasColumnName("addressline");
    }
}
