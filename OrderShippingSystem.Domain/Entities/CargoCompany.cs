using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderShippingSystem.Domain.Entities
{
    public class CargoCompany
    {
        //gu ıd 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  
        public string DeliveryAlgorithm { get; set; } = string.Empty;  
    }
}
