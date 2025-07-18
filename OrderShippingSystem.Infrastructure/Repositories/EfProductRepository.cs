using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Domain.Entities;
using OrderShippingSystem.Infrastructure.Persistence;

namespace OrderShippingSystem.Infrastructure.Repositories
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        public EfProductRepository(OrderShippingDbContext context) : base(context)
        {
        }
    }
}
