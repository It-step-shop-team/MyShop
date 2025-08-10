using MyShop.Domain.Entities;

namespace MyShop.Domain.Entities
{
    public class OrderItem
    {
        public required Guid Id { get; set; }
        public required Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public required Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
    }
}
