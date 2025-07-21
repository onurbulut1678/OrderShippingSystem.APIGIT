using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderShippingSystem.Application.Features.Orders.Dtos;
using System.Collections.Generic;

namespace OrderShippingSystem.Application.Features.Orders.Queries
{

    public class GetOrdersQuery : IRequest<List<OrderDto>> { }

}
