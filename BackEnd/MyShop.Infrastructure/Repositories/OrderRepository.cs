using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities;
using MyShop.Domain.IRepositories;
using MyShop.Domain.ListLikeEntities;
using MyShop.Infrastructure.Data;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository(ApplicationDbContext context) : IOrderRepository
    {
        public async Task<Order?> GetByIdAsync(Guid id) =>
            await context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.Category)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id);

        public async Task<ICollection<Order>> GetAllAsync() =>
            await context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.ProductTags)
                .ToListAsync();

        public async Task<ICollection<Order>> GetByUserIdAsync(Guid userId) => 
            await context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.Category)
                .Include(o => o.User)
                .Where(o => o.UserId == userId)
                .ToListAsync();

        public async Task<Order?> AddAsync(Order order) =>
            (await context.Orders.AddAsync(order)).Entity;

        public async Task<Order?> UpdateAsync(Order order)
        {
            Order? orderToUpdate = await context.Orders.FindAsync(order.Id);
            if (orderToUpdate is null)
                return null;
            
            orderToUpdate.OrderDate = order.OrderDate;
            
            orderToUpdate.OrderItems.Clear();
            foreach (var item in order.OrderItems)
                orderToUpdate.OrderItems.Add(item);
            
            orderToUpdate.ShippingAddress = order.ShippingAddress;
            
            orderToUpdate.UserId = order.UserId;
            
            orderToUpdate.Status = order.Status;
            
            return orderToUpdate;
        }

        public async Task<Order?> UpdateStatusAsync(Guid orderId, StatusType status)
        {
            Order? orderToUpdate = await context.Orders.FindAsync(orderId);

            if (orderToUpdate is null)
                return null;
            
            orderToUpdate.Status = status;
            
            return orderToUpdate;
        }

        public async Task<Order?> DeleteAsync(Guid id)
        {
            Order? orderToDelete = await context.Orders.FindAsync(id);
            if (orderToDelete is null)
                return null;

            context.Orders.Remove(orderToDelete);
            
            return orderToDelete;
        }
    }
}

