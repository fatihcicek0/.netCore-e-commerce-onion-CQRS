using E_commerce_.netcore.Application.Interfaces.UnitOfWork;
using MediatR;
using E_commerce_.netcore.Domain.Entities;
using SendGrid.Helpers.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Helpers.Errors.Model;
using E_commerce_.netcore.Application.Interfaces.AutoMapper;

namespace E_commerce_.netcore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UpdateProductCommandHandler(IMapper mapper,IUnitOfWork unitOfWork) { 
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);
            if (product == null) {
                 throw new NotFoundException("Güncellemek istediğiniz ürün bulunamadı.");
            }
            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
