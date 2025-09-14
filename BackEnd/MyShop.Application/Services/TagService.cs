using ErrorOr;
using MyShop.Application.DTOs.TagDTOs;
using MyShop.Application.Interfaces;
using MyShop.Application.Mappers;
using MyShop.Domain.IRepositories;

namespace MyShop.Application.Services;

public class TagService(ITagRepository tagRepository) : ITagService
{
    public async Task<ErrorOr<ICollection<PublicTagDto>>> GetAllTagsAsync()
    {
        var tags = (await tagRepository.GetAllAsync()).ToList();
        
        if (tags.Count == 0)
            return Error.Conflict(code:"Tag", description:"No tags found");

        return tags.Select(TagMapper.ToDto).ToList();
    }
}