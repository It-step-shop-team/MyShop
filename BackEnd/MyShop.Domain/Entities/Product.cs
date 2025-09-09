using MyShop.Domain.BaseEntities;
using MyShop.Domain.ListLikeEntities;

namespace MyShop.Domain.Entities
{
    /// <summary>
    /// Entity representing a product in the shop.
    /// Contains product details, category, and associated tags.
    /// </summary>
    public class Product : DbEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public int? StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
