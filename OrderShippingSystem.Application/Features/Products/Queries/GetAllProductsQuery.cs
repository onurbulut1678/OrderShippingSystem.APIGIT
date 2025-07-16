using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderShippingSystem.Application.Features.Products.DTOs;


namespace OrderShippingSystem.Application.Features.Products.Queries
{
    // isteği listeledik
    //queriiesde okuma işlemi yapılır. 
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {

    }
}
