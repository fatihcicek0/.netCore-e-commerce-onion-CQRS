using E_commerce_.netcore.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException:BaseException
    {
        public UserAlreadyExistException() : base("Böyle Bir Kullanıcı Zaten Var !") { }

    }
}
