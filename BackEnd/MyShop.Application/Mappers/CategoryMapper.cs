using MyShop.Application.DTOs.CategoryDTOs;
using MyShop.Domain.ListLikeEntities;

namespace MyShop.Application.Mappers;

public static class CategoryMapper
{
    public static PublicCategoryDto ToDto(Category category) =>
        new PublicCategoryDto { Name = category.Name, Id = category.Id };
}