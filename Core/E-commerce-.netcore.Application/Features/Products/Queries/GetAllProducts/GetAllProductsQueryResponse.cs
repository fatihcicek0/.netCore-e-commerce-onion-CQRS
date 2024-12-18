using E_commerce_.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce_.netcore.Application.Dtos;
namespace E_commerce_.netcore.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
       
        public bool IsOnSale { get; set; }
        public CategoryDto Category { get; set; }
    }
}
