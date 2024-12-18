using E_commerce_.netcore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }

        public bool IsOnSale { get; set; }
        public CategoryDto Category { get; set; }
    }
}
