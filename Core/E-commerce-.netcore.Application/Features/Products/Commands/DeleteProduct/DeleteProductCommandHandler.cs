using E_commerce_.netcore.Application.Interfaces.UnitOfWork;
using E_commerce_.netcore.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;


namespace E_commerce_.netcore.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork) { 
             this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            
            Product product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);
            if (product != null) 
            {
                await unitOfWork.GetWriteRepository<Product>().DeleteAsync(product);
                await unitOfWork.SaveAsync();

            }
            else
            {
                throw new NotFoundException("Silmek İstediğiniz Ürün Bulunamadı.");
            }
            return Unit.Value;
        }
    }
}
