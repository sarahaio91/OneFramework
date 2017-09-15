using System;

namespace OneFramework.Auth.Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(string email, DateTime expireIn);
    }
}
