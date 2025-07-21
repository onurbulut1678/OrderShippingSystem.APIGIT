using OrderShippingSystem.Application.Features.Orders.Dtos;
namespace OrderShippingSystem.Application.Features.Orders.Dtos
   

{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public int CargoCompanyId { get; set; }
    }

   
}
