using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderShippingSystem.Application.Features.Products.Queries;
using OrderShippingSystem.Application.Features.Products.DTOs;
using OrderShippingSystem.Application.Features.Products.Commands; // EKLE
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderShippingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get(CancellationToken cancellation)
        {
            var result = await _mediator.Send(new GetAllProductsQuery(), cancellation);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            var command = new CreateProductCommand(dto);
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = productId }, null);
        }
    
    }
}
