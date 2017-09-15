using System.Threading.Tasks;
using OneFramework.Hunter.Domain.Dtos.Account;

namespace OneFramework.Hunter.Domain.Services
{
    public interface IAccountService
    {
        Task<SignInResultDto> Login(LoginDto loginDto);
    }
}
