    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderShippingSystem.Domain.Entities;

namespace OrderShippingSystem.Application.Interfaces
{
  
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<int> AddAsync(Product product);

    }
}
