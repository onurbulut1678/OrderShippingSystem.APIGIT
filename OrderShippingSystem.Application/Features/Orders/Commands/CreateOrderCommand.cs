using MediatR;
using OrderShippingSystem.Application.Features.Orders.Dtos;

namespace OrderShippingSystem.Application.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public CreateOrderDto Order { get; set; }
        public CreateOrderCommand() { }

        public CreateOrderCommand(CreateOrderDto order)
        {
            Order = order;
        }
    }
}
