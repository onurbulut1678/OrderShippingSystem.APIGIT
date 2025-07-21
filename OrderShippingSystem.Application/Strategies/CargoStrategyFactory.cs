using OrderShippingSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderShippingSystem.Application.Strategies
{
    public class CargoStrategyFactory : ICargoStrategyFactory
    {
        public ICargoStrategy GetStrategy(int cargoCompanyId)
        {
            return cargoCompanyId switch
            {
                1 => new YurticiKargoStrategy(),
                2 => new ArasKargoStrategy(),
                3 => new MngKargoStrategy(),
                _ => throw new ArgumentException("Geçersiz kargo firması ID")
            };
        }
    }
}