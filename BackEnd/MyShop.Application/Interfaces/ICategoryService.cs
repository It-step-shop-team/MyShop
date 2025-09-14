using MyShop.Domain.ListLikeEntities;
using ErrorOr;
using MyShop.Application.DTOs.CategoryDTOs;

namespace MyShop.Application.Interfaces;

public interface ICategoryService
{
        Task<ErrorOr<ICollection<PublicCategoryDto>>> GetAllCategoriesAsync();
}