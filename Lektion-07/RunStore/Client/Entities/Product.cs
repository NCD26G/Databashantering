using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Entities;

[Table("products")]
public class Product
{
    [Column("id")]
    public int Id { get; set; }
    // [MaxLength(2048)]
    [Column("description", TypeName = "VARCHAR(2048)")]
    public string? Description { get; set; }
    // [MaxLength(128)]
    [Column("imageUrl", TypeName = "VARCHAR(128)")]
    public string? ImageUrl { get; set; }
    // [MaxLength(15)]
    [Column("itemNumber", TypeName = "VARCHAR(15)")]
    public required string ItemNumber { get; set; }
    // [MaxLength(80)]
    [Column("productName", TypeName = "VARCHAR(80)")]
    public required string Name { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
    // Navigation property
    public required Supplier Supplier { get; set; }
}