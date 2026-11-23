namespace Core.Entities;

public class City : BaseEntity
{
    public required string Name { get; set; }
    public List<PostalCode> PostalCodes { get; set; } = [];
}
