using System.Collections.Generic;

namespace Client.Entities;

public class Supplier : BaseEntity
{
    public required string Name { get; set; }
    public List<Product> Products { get; set; } = [];
}
