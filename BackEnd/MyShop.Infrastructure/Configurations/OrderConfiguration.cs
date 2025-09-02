using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.BaseEntities;
using MyShop.Domain.Entities;

namespace MyShop.Infrastructure.Configurations
{
    /// <summary>
    /// Configures the <see cref="Order"/> entity for Entity Framework Core.
    /// Defines keys, relationships, property constraints, and conversions.
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Configures the <see cref="Order"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Primary key
            builder.HasKey(o => o.Id);

            // Shipping address with max length
            builder.Property(o => o.ShippingAddress)
                   .HasMaxLength(500);

            // Status conversion to string with max length
            builder.Property(o => o.Status)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            // Relationship to ApplicationUser
            builder.HasOne(o => o.User)
                   .WithMany()
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
