using System.Collections.Generic;

namespace Client.Entities;

public class Address : BaseEntity
{
    public required string AddressLine { get; set; }
    public int PostalCodeId { get; set; }
    public PostalCode PostalCode { get; set; } = null!;
    public List<Customer> Customers { get; set; } = [];
}
