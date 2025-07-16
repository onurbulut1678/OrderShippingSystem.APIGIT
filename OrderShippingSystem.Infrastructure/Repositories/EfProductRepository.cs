using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Domain.Entities;
using OrderShippingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderShippingSystem.Infrastructure.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly OrderShippingDbContext _context;

        public EfProductRepository(OrderShippingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}