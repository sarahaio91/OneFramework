using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using OneFramework.Hunter.Domain.Auth;
using OneFramework.Hunter.Domain.Services;

namespace OneFramework.Hunter.Application.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(string email, DateTime expireIn)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(email, "TokenAuth")
                , new[] {
                    new Claim("Email", email)
                }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = AuthTokenOption.Issuer,
                Audience = AuthTokenOption.Audience,
                SigningCredentials = AuthTokenOption.SigningCredentials,
                Subject = identity,
                Expires = expireIn,
            });
            return handler.WriteToken(securityToken);
        }
    }
}
