using System;

namespace OneFramework.Hunter.Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(string email, DateTime expireIn);
    }
}
