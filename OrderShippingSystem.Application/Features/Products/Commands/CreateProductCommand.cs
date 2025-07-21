using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderShippingSystem.Application.Features.Products.DTOs;



namespace OrderShippingSystem.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public CreateProductDto Product { get; set; }
    }
}
