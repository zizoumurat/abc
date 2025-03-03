using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using porTIEVserver.Application.Features.Admin.Auth.Login;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Infrastructure.Options;

namespace porTIEVserver.Infrastructure.Services
{
    internal class JwtProvider(
        UserManager<AppUser> userManager,
        //RoleManager<AppRole> roleManager,
        IOptions<JwtOptions> jwtOptions
        
        ) : IJwtProvider
    {
        public async Task<LoginCommandResponse> CreateToken(AppUser user,
            string firmRef, List<int> firms,
            string roleRef, List<int> roles
            //, string menuRef, List<int> menus
            )
        {

            List<Claim> claims = new()
            {
                new Claim("Id"          , user.Id.ToString()),
                new Claim("UserName"    , user.UserName ?? string.Empty),
                new Claim("FullName"    , user.FullName ?? string.Empty),
                new Claim("Email"       , user.Email ?? string.Empty),
                new Claim("ImgUrl"      , user.ImgUrl ?? string.Empty),
                new Claim("IsAdmin"     , user.IsAdmin.ToString()),
                new Claim("FirmRef"     , firmRef ?? string.Empty),
                new Claim("Firms"       , JsonSerializer.Serialize(firms)),
                new Claim("RoleRef"     , roleRef ?? string.Empty),
                new Claim("Roles"       , JsonSerializer.Serialize(roles)),
                //new Claim("MenuRef"     , menuRef ?? string.Empty),
                //new Claim("Menus"       , JsonSerializer.Serialize(menus)),
            };

            DateTime expires = DateTime.UtcNow.AddMonths(1);


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));

            JwtSecurityToken jwtSecurityToken = new(
                issuer: jwtOptions.Value.Issuer,
                audience: jwtOptions.Value.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

            JwtSecurityTokenHandler handler = new();

            string token = handler.WriteToken(jwtSecurityToken);

            string refreshToken = Guid.NewGuid().ToString();
            DateTime refreshTokenExpires = expires.AddHours(1);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpires = refreshTokenExpires;

            await userManager.UpdateAsync(user);

            return new(token, refreshToken, refreshTokenExpires);
        }
    }
}
