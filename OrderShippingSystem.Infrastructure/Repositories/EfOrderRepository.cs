using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Domain.Entities;
using OrderShippingSystem.Infrastructure.Persistence;

namespace OrderShippingSystem.Infrastructure.Repositories
{
    public class EfOrderRepository : EfGenericRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(OrderShippingDbContext context) : base(context)
        {
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

