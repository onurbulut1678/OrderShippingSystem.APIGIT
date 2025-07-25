﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderShippingSystem.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; } 
        public decimal UnitPrice { get; set; }
        //yeni
        public int OrderId { get; set; } // Foreign key
        public Order Order { get; set; }
    }
}
