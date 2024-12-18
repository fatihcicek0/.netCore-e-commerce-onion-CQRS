using E_commerce_.netcore.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException:BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir lütfen tekrar giriş yapınız!"){ }
    }
}
