using Microsoft.AspNetCore.Mvc;
using OrderShippingSystem.Application.Features.Orders.Commands;
using OrderShippingSystem.Application.Features.Orders.Dtos;
using MediatR;
using OrderShippingSystem.Application.Features.Orders.Queries;

namespace OrderShippingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto orderDto)
        {
            var command = new CreateOrderCommand { Order = orderDto };
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }
    }
}
