using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class InvoiceTypeConfiguration : IEntityTypeConfiguration<InvoiceType>
{
    public void Configure(EntityTypeBuilder<InvoiceType> builder)
    {
        builder.ToTable("invoicetypes");
        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.InvoiceTypeName)
            .HasColumnName("invoicetype")
            .HasMaxLength(20)
            .IsRequired()
            .IsUnicode(false);
    }
}
