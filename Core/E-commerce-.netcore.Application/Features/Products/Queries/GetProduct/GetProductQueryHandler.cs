using E_commerce_.netcore.Application.Dtos;
using E_commerce_.netcore.Application.Interfaces.AutoMapper;
using E_commerce_.netcore.Application.Interfaces.UnitOfWork;
using E_commerce_.netcore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors;
using SendGrid.Helpers.Errors.Model;

namespace E_commerce_.netcore.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, GetProductQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetProductQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<GetProductQueryResponse> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = await unitOfWork.GetReadRepository<Product>().GetAsync(
                x => x.Id == request.Id,
                include:x=>x.Include(p=>p.Category));
            if (product == null) 
            {
                throw new NotFoundException("Ürün bulunamadı.");
            }
            var category=mapper.Map<CategoryDto,Category>(new Category());
            var map=mapper.Map<GetProductQueryResponse,Product>(product);
            return map;
        }
    }
}
