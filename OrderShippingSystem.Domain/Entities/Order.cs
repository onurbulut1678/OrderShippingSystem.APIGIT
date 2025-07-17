using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderShippingSystem.Domain.Entities;

namespace OrderShippingSystem.Domain.Entities
{
    public class Order
    {
        //orderstatus
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<OrderItem> Items { get; set; } = new();
        public int CargoCompanyId { get; set; }  
        public DateTime OrderDate { get; set; } = DateTime.Now;  
        public decimal TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; }

        //GİTHUB PROJE DENEMESİ
        //gıthup deneme
        public List<OrderItem> OrderItems { get; set; } = new();





    }
}
