using MyShop.Domain.BaseEntities;
using MyShop.Domain.Entities;

namespace MyShop.Domain.ListLikeEntities
{
    /// <summary>
    /// Entity representing a product tag.
    /// Tags can be used for categorization or filtering of products.
    /// </summary>
    public class Tag :  DbEntity
    {
        /// <summary>
        /// Name of the tag.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Collection of products associated with this tag.
        /// Represents a many-to-many relationship with the <see cref="Product"/> entity.
        /// </summary>
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
