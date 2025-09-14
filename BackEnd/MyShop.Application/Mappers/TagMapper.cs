using MyShop.Application.DTOs.TagDTOs;
using MyShop.Domain.ListLikeEntities;

namespace MyShop.Application.Mappers;

public static class TagMapper
{
    public static PublicTagDto ToDto(Tag tag) =>
        new PublicTagDto { Name = tag.Name,  Id = tag.Id };
}