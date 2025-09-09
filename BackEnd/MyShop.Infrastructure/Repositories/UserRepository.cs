using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;
using MyShop.Infrastructure.Data;

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

        public async Task<ICollection<ApplicationUser>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<ApplicationUser?> AddAsync(ApplicationUser user) =>
            (await context.Users.AddAsync(user)).Entity;
        

        public async Task<ApplicationUser?> UpdateAsync(ApplicationUser user)
        {
            ApplicationUser? userToUpdate = await context.Users.FindAsync(user.Id);
            
            if (userToUpdate is null)
                return null;
            
            userToUpdate.Email = user.Email;
            userToUpdate.Login = user.Login;
            userToUpdate.PasswordHash = user.PasswordHash;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.Address = user.Address;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            
            return user;
        }

        public async Task<ApplicationUser?> DeleteAsync(Guid id)
        {
            ApplicationUser? userToDelete = await context.Users.FindAsync(id);
            if (userToDelete is null)
                return null;
                
            context.Users.Remove(userToDelete);
            return userToDelete;
        }
    }
}
