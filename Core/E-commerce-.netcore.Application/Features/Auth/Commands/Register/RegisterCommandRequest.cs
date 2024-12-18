using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandRequest:IRequest<Unit>
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
