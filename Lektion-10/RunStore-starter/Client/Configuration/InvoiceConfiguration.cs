using Client.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configuration;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("invoices");
        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.InvoiceTypeId).HasColumnName("invoicetype_id");
        builder.Property(i => i.InvoiceNumber).HasColumnName("invoicenumber");
        builder.Property(i => i.OrderId).HasColumnName("order_id");
        builder.Property(i => i.InvoiceDate)
            .HasColumnName("invoicedate")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(i => i.DueDate).HasColumnName("duedate");

        builder.HasOne(i => i.SalesOrder)
            .WithMany(s => s.Invoices)
            .HasForeignKey(i => i.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.InvoiceType)
            .WithMany(t => t.Invoices)
            .HasForeignKey(i => i.InvoiceTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
