using OrderShippingSystem.Domain.Entities;

namespace OrderShippingSystem.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> AddAsync(Order order);
        // İleride ihtiyacına göre GetById, GetAll gibi metodlar da ekleyebiliriz.
    }
}
