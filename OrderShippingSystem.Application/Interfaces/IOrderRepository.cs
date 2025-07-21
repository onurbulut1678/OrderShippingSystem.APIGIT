using OrderShippingSystem.Domain.Entities;

namespace OrderShippingSystem.Application.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<int> AddAsync(Order order); // Sipariş eklerken ID dönecek şekilde özel
        IQueryable<Order> GetQueryable();
    }
}
