using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Entities;

namespace MyShop.Infrastructure.Configurations
{
    /// <summary>
    /// Configures the <see cref="OrderItem"/> entity for Entity Framework Core.
    /// Defines keys, relationships, property constraints, and precision for price.
    /// </summary>
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        /// <summary>
        /// Configures the <see cref="OrderItem"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Primary key
            builder.HasKey(oi => oi.Id);

            // Price with precision
            builder.Property(oi => oi.Price)
                   .HasPrecision(18, 2);

            // Relationship to Order
            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relationship to Product
            builder.HasOne(oi => oi.Product)
                   .WithMany()
                   .HasForeignKey(oi => oi.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
