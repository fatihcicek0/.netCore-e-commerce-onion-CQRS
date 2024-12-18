using FluentValidation;


namespace E_commerce_.netcore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommandRequest>
    {
           public CreateProductCommandValidator() {
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithName("Ürün Fiyatı");
            RuleFor(x => x.Discount).NotEmpty().WithName("Ürün İndirimi");
            RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0).WithName("Kategori");
            RuleFor(x => x.Description).NotEmpty().WithName("Ürün Açıklaması");
            RuleFor(x => x.Name).NotEmpty().WithName("Ürün İsmi");
        }
    }
}
