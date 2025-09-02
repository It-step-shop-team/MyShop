namespace MyShop.Application.Endpoints.dto
{
    /// <summary>
    /// A simplified Data Transfer Object (DTO) used for returning 
    /// short product information, for example in product lists or previews.
    /// </summary>
    public class ShortPublicProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }
    }
}
