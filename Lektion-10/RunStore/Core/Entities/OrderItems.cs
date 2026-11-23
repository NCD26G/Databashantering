namespace Core.Entities;

public class OrderItems
{
    public int SalesOrderId { get; set; }
    public int ProductId { get; set; }
    public SalesOrder SalesOrder { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
}
