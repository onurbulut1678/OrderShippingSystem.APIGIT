using Microsoft.AspNetCore.Mvc;
using OrderShippingSystem.Application.Features.Orders.Commands;
using OrderShippingSystem.Application.Features.Orders.Dtos;
using MediatR;

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
    }
}
