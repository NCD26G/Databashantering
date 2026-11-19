using System;
using System.Collections.Generic;

namespace Client.Entities;

public class Address : BaseEntity
{
    public required string AddressLine { get; set; }
    public int CustomerId { get; set; }
    public List<Customer> Customers { get; set; } = [];
}
