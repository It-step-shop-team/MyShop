using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;

namespace MyShop.Infrastructure.Persistence
{
    /// <summary>
    /// Represents the Entity Framework Core database context for the application.
    /// Provides DbSets for all entities and applies entity configurations.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationDbContext"/> with the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Gets or sets the products in the database.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the tags in the database.
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the product-tag relationships in the database.
        /// </summary>
        public DbSet<ProductTag> ProductTags { get; set; }

        /// <summary>
        /// Gets or sets the categories in the database.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the orders in the database.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the order items in the database.
        /// </summary>
        public DbSet<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Configures the model by applying all entity configurations from the assembly.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
