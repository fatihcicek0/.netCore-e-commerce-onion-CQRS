using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator() {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).MinimumLength(6).EmailAddress().WithName("Email");
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(50).MinimumLength(4).WithName("İsim Soyisim");
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50).MinimumLength(4).WithName("Parola");
        }
    }
}
