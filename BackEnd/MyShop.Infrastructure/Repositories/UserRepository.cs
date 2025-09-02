using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;


namespace MyShop.infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<ApplicationUser?> GetByIdAsync(Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser?> GetByLoginAsync(string login)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<IEnumerable<ApplicationUser>?> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<ApplicationUser?> AddAsync(ApplicationUser user)
        {
            var result = (await context.Users.AddAsync(user)).Entity;
            await context.SaveChangesAsync();
            return result;
        }

        public async Task<ApplicationUser?> UpdateAsync(ApplicationUser user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
