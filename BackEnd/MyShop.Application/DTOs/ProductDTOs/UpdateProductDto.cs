namespace MyShop.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) used for updating an existing product.
    /// Allows partial updates — only the provided properties will be updated.
    /// </summary>
    public class UpdateProductDto
    {
        /// <summary>
        /// The unique identifier of the product to update.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// The new name of the product.
        /// Optional. If null, the name will not be updated.
        /// </summary>
        public string? Name { get; init; }

        /// <summary>
        /// The new description of the product.
        /// Optional. If null, the description will not be updated.
        /// </summary>
        public string? Description { get; init; }

        /// <summary>
        /// The new price of the product.
        /// Optional. If null, the price will not be updated.
        /// </summary>
        public decimal? Price { get; init; }

        /// <summary>
        /// The new stock quantity of the product.
        /// Optional. If null, the stock quantity will not be updated.
        /// </summary>
        public int? StockQuantity { get; init; }

        /// <summary>
        /// The new URL of the product's image.
        /// Optional. If null, the image URL will not be updated.
        /// </summary>
        public string? ImageUrl { get; init; }

        /// <summary>
        /// The new category ID the product belongs to.
        /// Optional. If null, the category will not be updated.
        /// </summary>
        public Guid? CategoryId { get; init; }
    }
}
