using MyShop.Domain.BaseEntities;

namespace MyShop.Application.DTOs
{
    public class PublicOrderDto
    {
        public required Guid Id { get; init; }
        public required Guid UserId { get; init; }
        public required DateTime OrderDate { get; init; }
        public required StatusType Status { get; init; }
        public required string ShippingAddress { get; init; }
    }
}
