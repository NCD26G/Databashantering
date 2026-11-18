using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Entities;

public class Product
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }

    [Column("supplier_id")]
    public int SupplierId { get; set; }

    [ForeignKey("SupplierId")]
    public required Supplier Supplier { get; set; }
}