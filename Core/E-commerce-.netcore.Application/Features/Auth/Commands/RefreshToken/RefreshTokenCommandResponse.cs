using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        public string AccessToken { get; set; }
        public string Refreshtoken { get; set; }
      
    }
}
