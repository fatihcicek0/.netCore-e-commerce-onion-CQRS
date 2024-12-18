using E_commerce_.netcore.Application.Features.Products.Commands.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator() {
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithName("Ürün Fiyatı");
            RuleFor(x => x.Discount).NotEmpty().WithName("Ürün İndirimi");
            RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0).WithName("Kategori");
            RuleFor(x => x.Description).NotEmpty().WithName("Ürün Açıklaması");
            RuleFor(x => x.Name).NotEmpty().WithName("Ürün İsmi");
        }


    }
}
