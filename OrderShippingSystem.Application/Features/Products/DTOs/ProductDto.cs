using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//DTO data transfer object veri tabanı modelimizle eşletirdik
//UI KATMANI SADECE DTOLARLA KONUŞUR
namespace OrderShippingSystem.Application.Features.Products.DTOs
{
    public class ProductDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }

}
