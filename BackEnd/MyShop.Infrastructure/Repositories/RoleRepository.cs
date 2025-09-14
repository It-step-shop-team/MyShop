using Microsoft.EntityFrameworkCore;
using MyShop.Domain.IRepositories;
using MyShop.Domain.ListLikeEntities;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories;

public class RoleRepository(ApplicationDbContext context) : IRoleRepository
{
    public async Task<ICollection<Role>> GetAllAsync() =>
        await context.Roles.ToListAsync();

    public async Task<Role?> AddAsync(Role role) => 
        (await context.Roles.AddAsync(role)).Entity;

    public async Task<Role?> DeleteAsync(Role role)
    {
        var roleToDelete = await context.Roles.FindAsync(role.Id);
        if (roleToDelete is null)
            return null;
        
        context.Roles.Remove(roleToDelete);
        return roleToDelete;
    }
}