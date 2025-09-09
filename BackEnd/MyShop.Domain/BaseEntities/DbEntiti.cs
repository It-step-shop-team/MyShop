namespace MyShop.Domain.BaseEntities;

public abstract class DbEntity
{
    public Guid Id { get; init; } =  Guid.NewGuid();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}