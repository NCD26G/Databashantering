using System.Collections.Generic;

namespace Client.Entities;

public class AddressType : BaseEntity
{
    public required string AddressTypeName { get; set; }
    public List<Address> Addresses { get; set; } = [];
}
