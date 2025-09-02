namespace MyShop.Domain.Entities
{
    /// <summary>
    /// Entity representing a product in the shop.
    /// Contains product details, category, and associated tags.
    /// </summary>
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<ProductTag>? ProductTags { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
