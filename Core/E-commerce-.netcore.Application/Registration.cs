using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;
using E_commerce_.netcore.Application.Behaviors;
using E_commerce_.netcore.Application.Exceptions;
using E_commerce_.netcore.Application.Features.Auth.Rules;
namespace E_commerce_.netcore.Application
{
    public static class Registration
    {

        public static void AddApplication(this IServiceCollection services)
        {
            var assembly=Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
            services.AddScoped<AuthRules>();
        }
    }
}
