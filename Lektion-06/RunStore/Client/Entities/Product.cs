namespace Client.Entities;

public class Product
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public int Price { get; set; }
    // Navigation property
    public required Supplier Supplier { get; set; }
}