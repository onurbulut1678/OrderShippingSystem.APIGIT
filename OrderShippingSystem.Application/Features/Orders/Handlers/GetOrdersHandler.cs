using MediatR;
using OrderShippingSystem.Application.Features.Orders.Dtos;
using OrderShippingSystem.Application.Features.Orders.Queries;
using OrderShippingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace OrderShippingSystem.Application.Features.Orders.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            Log.Information(" Sipariş listeleme işlemi başlatıldı.");

            var orders = await _orderRepository.GetQueryable()
                .Include(x => x.CargoCompany)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                .ToListAsync(cancellationToken);
            Log.Information(" {OrderCount} adet sipariş veritabanından çekildi.", orders.Count);


            return orders.Select(order => new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                TotalPrice = order.TotalPrice,
                CreatedAt = order.CreatedAt,
                CargoCompanyName = order.CargoCompany?.Name,
                OrderItems = order.OrderItems.Select(item => new OrderItemDto
                {
                    ProductId = item.ProductId,
                    ProductName = item.Product?.Name ?? string.Empty,
                    Quantity = item.Quantity
                }).ToList()
                

            }).ToList();
          //  Log.Information(" Siparişler başarıyla DTO'ya dönüştürüldü ve döndürüldü.");
          //bunu yanlış yere koyduk muhtemelen
        }
    }
}
