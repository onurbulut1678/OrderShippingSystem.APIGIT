using OrderShippingSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderShippingSystem.Application.Strategies
{
    public class ArasKargoStrategy : ICargoStrategy
    {
        public decimal CalculatePrice(decimal orderTotal)
        {
            return 35m; // Sabit 20 TL olsun bu da
        }
    }
}
