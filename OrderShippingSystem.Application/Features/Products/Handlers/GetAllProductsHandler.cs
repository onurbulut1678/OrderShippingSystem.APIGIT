using MediatR;
using OrderShippingSystem.Application.Features.Products.DTOs;
using OrderShippingSystem.Application.Features.Products.Queries;
using OrderShippingSystem.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderShippingSystem.Application.Features.Products.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category
            }).ToList();

            return result;
        }
    }
}
