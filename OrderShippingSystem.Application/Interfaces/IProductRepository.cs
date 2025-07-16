    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderShippingSystem.Domain.Entities;

namespace OrderShippingSystem.Application.Interfaces
{
    //burda nasıl yapıldığı değil ne yapıldığı gösterilir;
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
    }
}
