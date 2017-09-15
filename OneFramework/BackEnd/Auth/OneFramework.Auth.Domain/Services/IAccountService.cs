using System.Threading.Tasks;
using OneFramework.Auth.Domain.Dtos.Account;

namespace OneFramework.Auth.Domain.Services
{
    public interface IAccountService
    {
        Task<SignInResultDto> Login(LoginDto loginDto);
    }
}
