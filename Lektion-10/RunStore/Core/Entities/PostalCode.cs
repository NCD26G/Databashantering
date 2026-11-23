namespace Core.Entities;

public class PostalCode : BaseEntity
{
    public required string Code { get; set; }
    public int CityId { get; set; }
    public City City { get; set; } = null!;
    public List<Address> Addresses { get; set; } = [];
}
