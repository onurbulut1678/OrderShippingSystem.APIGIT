using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderShippingSystem.Application.Features.Orders.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CargoCompanyName { get; set; }
        //yeni ekledim

        public List<OrderItemDto> OrderItems { get; set; } = new();
      
    }
}
