namespace Core.Entities;

public class InvoiceType : BaseEntity
{
    public required string InvoiceTypeName { get; set; }
    public List<Invoice> Invoices { get; set; } = [];
}
