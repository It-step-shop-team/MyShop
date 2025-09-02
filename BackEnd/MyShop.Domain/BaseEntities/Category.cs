namespace MyShop.Domain.BaseEntities
{
    /// <summary>
    /// Base entity representing a product category.
    /// Contains a unique identifier and the category name.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Unique identifier of the category.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Name of the category.
        /// </summary>
        public required string Name { get; init; }
    }
}
