using MediatR;
using OrderShippingSystem.Application.Features.Orders.Commands;
using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Domain.Entities;

namespace OrderShippingSystem.Application.Features.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
           
            var order = new Order
            {
                UserId = request.Order.UserId,
                TotalPrice = request.Order.TotalPrice,
                CreatedAt = DateTime.UtcNow,
                CargoCompanyId = request.Order.CargoCompanyId
            };

           
            order.OrderItems = request.Order.Items.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = 0 
            }).ToList();

            
            await _orderRepository.AddAsync(order);

            return order.Id;
        }
    }
}
