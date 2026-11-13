using System;
using System.Collections.Generic;

namespace Client.Entities;

public class Supplier
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Product> Products { get; set; } = [];
}
