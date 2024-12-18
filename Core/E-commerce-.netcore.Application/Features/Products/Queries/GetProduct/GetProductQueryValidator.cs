using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryValidator:AbstractValidator<GetProductQueryRequest>
    {
        public GetProductQueryValidator() {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
