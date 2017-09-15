using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace OneFramework.Hunter.Domain.Auth
{
    public class AuthTokenOption
    {
        public static string Audience { get; } = "http://localhost:12947/";
        public static string Issuer { get; } = "OneIssuer";
        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);

        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(30);
        public const string TokenType = JwtBearerDefaults.AuthenticationScheme;
    }
}
