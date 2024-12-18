using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandRequest:IRequest<Unit>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
