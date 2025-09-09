using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using MyShop.API.Extensions;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;
using MyShop.Domain.ListLikeEntities;

namespace MyShop.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await orderService.GetAllOrdersAsync();
            return result.GetIActionResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await orderService.GetOrderByIdAsync(id);
            return result.GetIActionResult();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUserId(Guid userId)
        {
            var result = await orderService.GetOrdersByUserIdAsync(userId);
            return result.GetIActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await orderService.CreateOrderAsync(createOrderDto);
            return result.GetIActionResult();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] string strStatus)
        {
            if (!(Enum.TryParse<StatusType>(strStatus, out var status)))
            {
                ErrorOr<Order> error = Error.Validation(
                    code: "Order.Update.StatusType",
                    description: "Status type is not found.");
                return error.GetIActionResult();
            }
            
            var result = await orderService.UpdateOrderStatusAsync(id, status);
            return result.GetIActionResult();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            var result = await orderService.CancelOrderAsync(id);
            return result.GetIActionResult();
        }
    }
}
