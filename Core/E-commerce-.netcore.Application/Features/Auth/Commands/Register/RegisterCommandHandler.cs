using E_commerce_.netcore.Application.Interfaces.Token;
using E_commerce_.netcore.Application.Interfaces.UnitOfWork;
using E_commerce_.netcore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using E_commerce_.netcore.Application.Features.Auth.Rules;
using MediatR;

namespace E_commerce_.netcore.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITokenService tokenService;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly AuthRules authRules;

        public RegisterCommandHandler(AuthRules authRules,IUnitOfWork unitOfWork,ITokenService tokenService,UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
            this.unitOfWork = unitOfWork;
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));
            User user = new()
            {
                Email = request.Email,
                FullName = request.FullName,
                UserName=request.FullName,
                SecurityStamp  =Guid.NewGuid().ToString()
            }; 
            IdentityResult result =await userManager.CreateAsync(user,request.Password);
            if (result.Succeeded) { 
                if(!await roleManager.RoleExistsAsync("user"))
                {
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
                    await userManager.AddToRoleAsync(user, "user");
                }
            }

            return Unit.Value;
        }

    }
}
