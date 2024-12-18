using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator:AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidator() {
            RuleFor(x => x.AccessToken).NotEmpty();

            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
