using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Entities;

namespace MyShop.Infrastructure.Configurations
{
    /// <summary>
    /// Configures the <see cref="Product"/> entity for Entity Framework Core.
    /// Defines keys, relationships, property constraints, and column types.
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Configures the <see cref="Product"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Primary key
            builder.HasKey(p => p.Id);

            // Name property configuration
            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(64);

            builder.Property(p => p.Description)
                    .IsRequired()
                    .HasMaxLength(200);
            
            // Price property with decimal type
            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");

            // Relationship with Category
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relationship with ProductTags (many-to-many)
            builder.HasMany(p => p.ProductTags)
                   .WithOne(pt => pt.Product)
                   .HasForeignKey(pt => pt.ProductId);
        }
    }
}
