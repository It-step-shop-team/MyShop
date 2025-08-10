using Microsoft.AspNetCore.Mvc;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;

namespace MyShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicOrderDto>>> GetAllOrders()
        {
            var result = await _orderService.GetAllOrdersAsync();
            return result.Match<ActionResult<IEnumerable<PublicOrderDto>>>(
                orders => Ok(orders),
                errors => Problem(errors.First().Description)
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublicOrderDto>> GetOrderById(Guid id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            return result.Match<ActionResult<PublicOrderDto>>(
                order => order != null ? Ok(order) : NotFound(),
                errors => Problem(errors.First().Description)
            );
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PublicOrderDto>>> GetOrdersByUserId(Guid userId)
        {
            var result = await _orderService.GetOrdersByUserIdAsync(userId);
            return result.Match<ActionResult<IEnumerable<PublicOrderDto>>>(
                orders => Ok(orders),
                errors => Problem(errors.First().Description)
            );
        }

        [HttpPost]
        public async Task<ActionResult<PublicOrderDto>> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _orderService.CreateOrderAsync(createOrderDto);
            return result.Match<ActionResult<PublicOrderDto>>(
                order => CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order),
                errors => Problem(errors.First().Description)
            );
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] string status)
        {
            var result = await _orderService.UpdateOrderStatusAsync(id, status);
            return result.Match<IActionResult>(
                success => success ? NoContent() : NotFound(),
                errors => Problem(errors.First().Description)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            var result = await _orderService.CancelOrderAsync(id);
            return result.Match<IActionResult>(
                success => success ? NoContent() : NotFound(),
                errors => Problem(errors.First().Description)
            );
        }
    }
}
