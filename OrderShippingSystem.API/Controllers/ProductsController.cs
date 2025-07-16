using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderShippingSystem.Application.Features.Products.Queries;
using OrderShippingSystem.Application.Features.Products.DTOs;
using OrderShippingSystem.Application.Features.Orders.Commands;
using OrderShippingSystem.Application.Features.Orders.Dtos;

namespace OrderShippingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Dependency ınjection burda yaptık
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //tokenlama yapılacak

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get(CancellationToken cancellation)
        {
            var result = await _mediator.Send(new GetAllProductsQuery(),cancellation);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            var command = new CreateOrderCommand(orderDto);
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }
    }
}
