using E_commerce_.netcore.Application.Interfaces.AutoMapper;
using E_commerce_.netcore.Application.Interfaces.UnitOfWork;
using E_commerce_.netcore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) {
           this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Name,request.Price,request.Discount,request.Description,request.CategoryId);
            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
