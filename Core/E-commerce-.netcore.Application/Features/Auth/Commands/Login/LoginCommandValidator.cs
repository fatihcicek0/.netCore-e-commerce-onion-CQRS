using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator:AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidator() { 
            RuleFor(x=>x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50).MinimumLength(4);
        }
    }
}
