using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Entities;

public class SalesOrder
{
    public int Id { get; set; }
    public required string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<OrderItems> Items { get; set; } = [];
}
