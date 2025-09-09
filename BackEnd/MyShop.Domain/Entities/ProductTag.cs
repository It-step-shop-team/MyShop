using MyShop.Domain.ListLikeEntities;

namespace MyShop.Domain.Entities
{
    /// <summary>
    /// Join entity representing the many-to-many relationship between products and tags.
    /// Links a <see cref="Product"/> with a <see cref="Tag"/>.
    /// </summary>
    public class ProductTag
    {
        /// <summary>
        /// Identifier of the associated product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property to the associated product.
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Identifier of the associated tag.
        /// </summary>
        public Guid TagId { get; set; }

        /// <summary>
        /// Navigation property to the associated tag.
        /// </summary>
        public Tag? Tag { get; set; }
    }
}
