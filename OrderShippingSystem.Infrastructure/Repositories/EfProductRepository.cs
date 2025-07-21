using Microsoft.EntityFrameworkCore;
using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Domain.Entities;
using OrderShippingSystem.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace OrderShippingSystem.Infrastructure.Repositories
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        private readonly OrderShippingDbContext _context;

        public EfProductRepository(OrderShippingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
