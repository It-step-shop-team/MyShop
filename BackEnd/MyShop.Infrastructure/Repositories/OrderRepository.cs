using Microsoft.EntityFrameworkCore;

using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;
using MyShop.Infrastructure.Persistence;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetByIdAsync(Guid id) =>
            await _context.Orders
                          .Include(o => o.OrderItems)
                          .ThenInclude(oi => oi.Product)
                          .ThenInclude(p => p.Category)
                          .Include(o => o.User)
                          .FirstOrDefaultAsync(o => o.Id == id);

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _context.Orders
                          .Include(o => o.OrderItems)
                          .ThenInclude(oi => oi.Product)
                          .ThenInclude(p => p.Tags)
                          .ToListAsync();

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}

