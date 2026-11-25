namespace Core.Entities;

public class SalesOrder : BaseEntity
{
    public required string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<OrderItems> Items { get; set; } = [];
    public List<Invoice> Invoices { get; set; } = [];
}
