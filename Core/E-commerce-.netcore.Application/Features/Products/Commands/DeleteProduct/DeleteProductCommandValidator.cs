using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandValidator() {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0); 
        }
    }
}
