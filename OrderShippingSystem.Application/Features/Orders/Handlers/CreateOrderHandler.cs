using MediatR;
using OrderShippingSystem.Application.Features.Orders.Commands;
using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Application.Strategies;
using OrderShippingSystem.Domain.Entities;
using Serilog;

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
            Log.Information(" Sipariş oluşturma işlemi başladı. KullanıcıId: {UserId}", request.Order.UserId);
            // 1. Kargo stratejisini al
            var strategy = _cargoStrategyFactory.GetStrategy(request.Order.CargoCompanyId);

            // 2. Kargo ücretini hesapla
            decimal shippingPrice = strategy.CalculatePrice(request.Order.TotalPrice);
            Log.Information(" Kargo ücreti hesaplandı: {ShippingPrice}", shippingPrice);
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
            Log.Information(" Sipariş nesnesi oluşturuldu. Ürün adedi: {ItemCount}", order.OrderItems.Count);

            // 5. Siparişi kaydet
            await _orderRepository.AddAsync(order);
            Log.Information(" Sipariş başarıyla kaydedildi. OrderId: {OrderId}", order.Id);

            return order.Id;
        }
    }
}
