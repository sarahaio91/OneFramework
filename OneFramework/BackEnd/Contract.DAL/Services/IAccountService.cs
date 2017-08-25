using System.Threading.Tasks;
using Contract.BUS.Dtos;

namespace Domain.Services
{
    public interface IAccountService
    {
        Task<SignInResultDto> Login(LoginDto loginDto);
    }
}
