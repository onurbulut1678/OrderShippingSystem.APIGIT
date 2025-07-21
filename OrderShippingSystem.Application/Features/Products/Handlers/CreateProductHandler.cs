using MediatR;
using OrderShippingSystem.Application.Features.Products.Commands;
using OrderShippingSystem.Application.Features.Products.DTOs;
using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OrderShippingSystem.Application.Features.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Product;

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category
            };

            return await _productRepository.AddAsync(product);
        }
    }
}
