using ErrorOr;
using MyShop.Application.DTOs.CategoryDTOs;
using MyShop.Application.Interfaces;
using MyShop.Application.Mappers;
using MyShop.Domain.IRepositories;

namespace MyShop.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) :  ICategoryService
{
    public async Task<ErrorOr<ICollection<PublicCategoryDto>>> GetAllCategoriesAsync()
    {
        var categories = (await categoryRepository.GetAllAsync()).ToList();
        
        if (categories.Count == 0)
            return Error.Conflict(code: "Category", description: "Category not found");
        
        return categories.Select(CategoryMapper.ToDto).ToList();
    }
}