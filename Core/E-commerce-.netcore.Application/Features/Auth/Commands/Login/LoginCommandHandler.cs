using E_commerce_.netcore.Application.Features.Auth.Rules;
using E_commerce_.netcore.Application.Interfaces.Token;
using E_commerce_.netcore.Application.Interfaces.UnitOfWork;
using E_commerce_.netcore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Errors.Model;
using System.IdentityModel.Tokens.Jwt;

namespace E_commerce_.netcore.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler:IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;
        private readonly IConfiguration configuration;
        public LoginCommandHandler(IConfiguration configuration,AuthRules authRules, IUnitOfWork unitOfWork, ITokenService tokenService, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
            this.unitOfWork = unitOfWork;
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.authRules = authRules;
            this.configuration = configuration;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user=await userManager.FindByEmailAsync(request.Email);
            if (user == null) {
                throw new NotFoundException("Böyle bir kullanıcı bulunmuyor!");
            }
            bool checkPassword=await userManager.CheckPasswordAsync(user, request.Password);
            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);
            IList<string> roles=await userManager.GetRolesAsync(user);
            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();
            var _ = int.TryParse(configuration["JWT:RefreshTokenValidityDays"], out int refreshTokenValidityDays);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token=new JwtSecurityTokenHandler().WriteToken(token);
            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                AccessToken = _token,
                RefreshToken = refreshToken
            };


        }
    }
}
