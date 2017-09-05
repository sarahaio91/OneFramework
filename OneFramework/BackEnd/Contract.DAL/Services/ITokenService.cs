using System;

namespace Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(string email, DateTime expireIn);
    }
}
