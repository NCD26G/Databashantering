namespace Client.DTOs;

public class ProductListDto
{
    public int Id { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Supplier { get; set; }
}
