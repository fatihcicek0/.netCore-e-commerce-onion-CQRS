using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Exceptions
{
    public static  class ConfigureExceptionMiddleware
    {
        public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder appBuilder) 
        {
          appBuilder.UseMiddleware<ExceptionMiddleware>();
        }

    }
}
