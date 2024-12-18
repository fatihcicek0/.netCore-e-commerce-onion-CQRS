using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryRequest:IRequest<GetProductQueryResponse>
    {
        public int Id { get; set; }
    }
}
