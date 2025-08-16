namespace MyShop.Domain.BaseEntities;

public class Category
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}