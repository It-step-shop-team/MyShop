namespace MyShop.Domain.BaseEntities;

public class Tag
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}