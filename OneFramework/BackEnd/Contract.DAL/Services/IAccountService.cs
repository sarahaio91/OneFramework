using System.Threading.Tasks;
using Domain.Dtos.Account;

namespace Domain.Services
{
    public interface IAccountService
    {
        Task<SignInResultDto> Login(LoginDto loginDto);
    }
}
