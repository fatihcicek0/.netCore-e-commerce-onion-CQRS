using E_commerce_.netcore.Application.Interfaces.Token;
using MediatR;
using Microsoft.AspNetCore.Identity;
using E_commerce_.netcore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using E_commerce_.netcore.Application.Features.Auth.Rules;
using System.IdentityModel.Tokens.Jwt;

namespace E_commerce_.netcore.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler:IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly ITokenService tokenService;
        private readonly UserManager<User> userManager; 
        private readonly AuthRules authRules;
        public RefreshTokenCommandHandler(AuthRules authRules,ITokenService tokenService, UserManager<User> userManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.authRules = authRules;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var principal =  tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email=principal.FindFirstValue(ClaimTypes.Email);


            User user=await userManager.FindByEmailAsync(email);
            IList<string> roles=await userManager.GetRolesAsync(user);
            await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user,roles);
            string newRefreshtoken = tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshtoken;
            await userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                Refreshtoken = newRefreshtoken
            };
        }
    }
}
