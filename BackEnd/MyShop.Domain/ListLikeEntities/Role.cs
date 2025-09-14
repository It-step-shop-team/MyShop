using MyShop.Domain.BaseEntities;
using MyShop.Domain.Entities;

namespace MyShop.Domain.ListLikeEntities;

public class Role : DbEntity
{
    public required string Name { get; set; }
    
    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}