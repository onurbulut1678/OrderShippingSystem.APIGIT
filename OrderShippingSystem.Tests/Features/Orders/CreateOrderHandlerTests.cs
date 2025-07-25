using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using OrderShippingSystem.Application.Features.Orders.Commands;
using OrderShippingSystem.Application.Features.Orders.Dtos;
using OrderShippingSystem.Application.Features.Orders.Handlers;
using OrderShippingSystem.Application.Interfaces;

namespace OrderShippingSystem.Tests.Features.Orders
{
    public class CreateOrderHandlerTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<ICargoStrategyFactory> _mockCargoStrategyFactory;
        private readonly CreateOrderHandler _handler;

        public CreateOrderHandlerTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockCargoStrategyFactory = new Mock<ICargoStrategyFactory>();

            _handler = new CreateOrderHandler(
                _mockOrderRepository.Object,
                _mockCargoStrategyFactory.Object
            );
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsOrderId()
        {
            
            var command = new CreateOrderCommand(new CreateOrderDto
            {
                UserId = 1,
                CargoCompanyId = 2,
                TotalPrice = 100,
                Items = new List<OrderItemDto>
                {
                    new OrderItemDto
                    {
                        ProductId = 1,
                        Quantity = 2
                    }
                }
            });

            _mockOrderRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.Order>()))
                .ReturnsAsync(1); 

            
            var result = await _handler.Handle(command, CancellationToken.None);

            
            Assert.Equal(1, result);
        }
    }
}
