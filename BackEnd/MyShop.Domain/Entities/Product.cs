using MyShop.Domain.BaseEntities;

namespace MyShop.Domain.Entities
{
    public class Product
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int StockQuantity { get; set; }
        public required string ImageUrl { get; set; }
        public required CategoryType Category { get; set; }
        public List<TagType>? Tags { get; set; }
        public required DateTime CreatedDate { get; set; }
        public required DateTime UpdatedDate { get; set; }
    }
}
