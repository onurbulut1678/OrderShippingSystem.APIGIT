using MediatR;
using OrderShippingSystem.Application.Features.Products.Commands;
using OrderShippingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OrderShippingSystem.Application.Features.Products.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteAsync(request.Id);
        }
    }
}
