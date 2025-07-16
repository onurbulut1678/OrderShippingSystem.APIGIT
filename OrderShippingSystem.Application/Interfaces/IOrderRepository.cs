using OrderShippingSystem.Domain.Entities;

namespace OrderShippingSystem.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        // İleride ihtiyacına göre GetById, GetAll gibi metodlar da ekleyebiliriz.
    }
}
