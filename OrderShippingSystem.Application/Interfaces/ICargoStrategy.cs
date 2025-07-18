using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderShippingSystem.Application.Interfaces
{
    public interface ICargoStrategy
    {
        decimal CalculatePrice(decimal orderTotal);
    }
}
