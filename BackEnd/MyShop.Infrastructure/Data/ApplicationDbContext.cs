using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyShop.Domain.Entities;
using MyShop.Domain.ListLikeEntities;

namespace MyShop.Infrastructure.Data
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
        
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Role>  Roles { get; set; }

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
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        
        /* КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ
         КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ 
         КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ 
         КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ 
         КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ КОСТЫЛЬ*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => 
                    warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        
        /// <summary>
        /// Configures the model by applying all entity configurations from the assembly.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for the context.</param>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            
            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Electronics", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Clothing", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Books", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Home & Kitchen", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Sports & Outdoors", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Beauty & Health", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "Toys & Games", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "Automotive", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), Name = "Pet Supplies", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Category { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "Office & Stationery", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // Tags
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), Name = "New", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaaa2-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), Name = "Sale", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaaa3-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), Name = "Popular", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaaa4-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), Name = "Limited Edition", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaaa5-aaaa-aaaa-aaaa-aaaaaaaaaaa5"), Name = "Free Shipping", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaaa6-aaaa-aaaa-aaaa-aaaaaaaaaaa6"), Name = "Eco-Friendly", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaaa7-aaaa-aaaa-aaaa-aaaaaaaaaaa7"), Name = "Handmade", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaaa8-aaaa-aaaa-aaaa-aaaaaaaaaaa8"), Name = "Best Seller", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaaa9-aaaa-aaaa-aaaa-aaaaaaaaaaa9"), Name = "On Discount", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa10-aaaa-aaaa-aaaa-aaaaaaaaaaa0"), Name = "Limited Stock", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa11-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), Name = "Trending", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa12-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), Name = "Gift", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa13-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), Name = "Seasonal", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa14-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), Name = "Exclusive", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa15-aaaa-aaaa-aaaa-aaaaaaaaaaa5"), Name = "Bundle", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa16-aaaa-aaaa-aaaa-aaaaaaaaaaa6"), Name = "Limited Time Offer", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa17-aaaa-aaaa-aaaa-aaaaaaaaaaa7"), Name = "Preorder", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa18-aaaa-aaaa-aaaa-aaaaaaaaaaa8"), Name = "Popular Choice", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa19-aaaa-aaaa-aaaa-aaaaaaaaaaa9"), Name = "Hot Deal", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Tag { Id = Guid.Parse("aaaaaa20-aaaa-aaaa-aaaa-aaaaaaaaaaa0"), Name = "Back in Stock", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );
        }
    }
}
