namespace Client.Entities;

public class Product : BaseEntity
{
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public int SupplierId { get; set; }
    public required Supplier Supplier { get; set; }
}