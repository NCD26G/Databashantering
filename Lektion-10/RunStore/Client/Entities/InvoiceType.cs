using System.Collections.Generic;

namespace Client.Entities;

public class InvoiceType : BaseEntity
{
    public required string InvoiceTypeName { get; set; }
    public List<Invoice> Invoices { get; set; } = [];
}
