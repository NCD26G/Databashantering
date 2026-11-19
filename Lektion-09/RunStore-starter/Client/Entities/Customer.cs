using System.Collections.Generic;

namespace Client.Entities;

public class Customer : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public List<SalesOrder> SalesOrders { get; set; } = [];
    public List<Address> Addresses { get; set; } = [];
}
