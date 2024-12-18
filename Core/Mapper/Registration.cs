
using E_commerce_.netcore.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
namespace E_commerce_.netcore.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
