using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Domain.Entities;
using OrderShippingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderShippingSystem.Infrastructure.Repositories
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly OrderShippingDbContext _context;

        public EfOrderRepository(OrderShippingDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            foreach (var item in order.OrderItems)
            {
                item.OrderId = order.Id;
            }

            await _context.SaveChangesAsync();
            return order.Id;
        }
    }
}
