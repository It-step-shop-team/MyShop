using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Entities;

namespace MyShop.Infrastructure.Configurations;

public class RefreshTokensConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        // Название таблицы
        builder.ToTable("RefreshTokens");

        // Первичный ключ
        builder.HasKey(rt => rt.Id);

        // Связь с пользователем (если у тебя есть таблица Users)
        builder.HasIndex(rt => rt.UserId);

        // Сам токен (уникальный!)
        builder.Property(rt => rt.Token)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasIndex(rt => rt.Token).IsUnique();

        // Время жизни
        builder.Property(rt => rt.ExpiresAt)
            .IsRequired();

        // Признак отзыва
        builder.Property(rt => rt.IsRevoked)
            .HasDefaultValue(false);
    }
}