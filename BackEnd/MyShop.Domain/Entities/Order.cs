using MyShop.Domain.Entities;

namespace MyShop.Domain.Entities
{
    public class Order
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public required DateTime OrderDate { get; set; }
        public required string Status { get; set; }
        public required string ShippingAddress { get; set; }
        public IEnumerable<OrderItem>? OrderItems { get; set; }
    }
}
