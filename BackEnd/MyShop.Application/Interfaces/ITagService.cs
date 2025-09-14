using ErrorOr;
using MyShop.Application.DTOs.TagDTOs;

namespace MyShop.Application.Interfaces;

public interface ITagService
{
        Task<ErrorOr<ICollection<PublicTagDto>>> GetAllTagsAsync();
}