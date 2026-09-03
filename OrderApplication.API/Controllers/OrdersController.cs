using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderApplication.Application.Orders;
using OrderApplication.Domain.Entities;

namespace OrderApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService) { 
            _orderService = orderService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrder([FromRoute]int id, CancellationToken ct)
        {
            var order = await _orderService.GetOrder(id, ct);

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto order, CancellationToken ct)
        {
            var orderId = await _orderService.CreateOrder(order, ct);

            return CreatedAtAction("CreateOrder", new { id = orderId });
        }

        [HttpPatch]
        [Route("{id}/cancel")]
        public async Task<IActionResult> CancelOrder([FromRoute] int id, CancellationToken ct)
        {
            await _orderService.CancelOrder(id, ct);

            return NoContent();
        }
    }
}
