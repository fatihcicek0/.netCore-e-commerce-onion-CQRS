using E_commerce_.netcore.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShoundNotBeInvalidException:BaseException
    {
        public EmailOrPasswordShoundNotBeInvalidException() : base("Şifre yada Email hatalı!") { }
    }
}
