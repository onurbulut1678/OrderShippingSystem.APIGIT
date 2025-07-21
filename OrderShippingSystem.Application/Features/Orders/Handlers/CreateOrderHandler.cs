using MediatR;
using OrderShippingSystem.Application.Features.Orders.Commands;
using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Application.Strategies;
using OrderShippingSystem.Domain.Entities;

namespace OrderShippingSystem.Application.Features.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICargoStrategyFactory _cargoStrategyFactory;

        public CreateOrderHandler(IOrderRepository orderRepository, ICargoStrategyFactory cargoStrategyFactory)
        {
            _orderRepository = orderRepository;
            _cargoStrategyFactory = cargoStrategyFactory;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // 1. Kargo stratejisini al
            var strategy = _cargoStrategyFactory.GetStrategy(request.Order.CargoCompanyId);

            // 2. Kargo ücretini hesapla
            decimal shippingPrice = strategy.CalculatePrice(request.Order.TotalPrice);

            // 3. Siparişi oluştur
            var order = new Order
            {
                UserId = request.Order.UserId,
                TotalPrice = request.Order.TotalPrice + shippingPrice, // Kargo dahil
                CreatedAt = DateTime.UtcNow,
                CargoCompanyId = request.Order.CargoCompanyId
            };

            // 4. Sipariş ürünlerini oluştur
            order.OrderItems = request.Order.Items.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = 0
            }).ToList();

            // 5. Siparişi kaydet
            await _orderRepository.AddAsync(order);

            return order.Id;
        }
    }
}
