using System;

namespace Client.Entities;

public class Invoice : BaseEntity
{
    public int InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }
    public int InvoiceTypeId { get; set; }
    public InvoiceType InvoiceType { get; set; } = null!;
    public int OrderId { get; set; }
    public SalesOrder SalesOrder { get; set; } = null!;
}
