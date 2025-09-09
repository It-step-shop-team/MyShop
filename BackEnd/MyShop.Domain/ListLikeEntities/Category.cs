using MyShop.Domain.BaseEntities;
using MyShop.Domain.Entities;

namespace MyShop.Domain.ListLikeEntities
{
    /// <summary>
    /// Entity representing a product category.
    /// Categories can be used to organize and group products.
    /// </summary>
    public class Category : DbEntity
    {
        /// <summary>
        /// Name of the category.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Collection of products associated with this category.
        /// Represents a one-to-many relationship with the <see cref="Product"/> entity.
        /// </summary>
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
