using OrderShippingSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderShippingSystem.Application.Strategies
{
    public class MngKargoStrategy : ICargoStrategy
    {
        public decimal CalculatePrice(decimal orderTotal)
        {
            return 40m; //25 de bu olsun
        }
    }
}