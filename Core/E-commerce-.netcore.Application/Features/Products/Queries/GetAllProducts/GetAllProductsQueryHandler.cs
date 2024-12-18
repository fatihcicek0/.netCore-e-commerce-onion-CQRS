using E_commerce_.netcore.Domain;
using E_commerce_.netcore.Application.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce_.netcore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using E_commerce_.netcore.Application.Interfaces.AutoMapper;
using E_commerce_.netcore.Application.Dtos;

namespace E_commerce_.netcore.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest,IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper) { 
        this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>()
                .GetAllAsync(
                include: i => i.Include(p => p.Category),
                orderBy: i => i.OrderBy(p => p.Price)
                );
            var category = mapper.Map<CategoryDto, Category>(new Category());
            var map=mapper.Map<GetAllProductsQueryResponse,Product>(products);
            return map;
            
        }


    }
}
