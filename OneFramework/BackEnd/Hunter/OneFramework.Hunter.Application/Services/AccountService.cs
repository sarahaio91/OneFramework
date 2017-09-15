using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OneFramework.Hunter.Domain.Dtos.Account;
using OneFramework.Hunter.Domain.Entities.User;
using OneFramework.Hunter.Domain.Services;

namespace OneFramework.Hunter.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResultDto> Login(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, loginDto.RememberMe, lockoutOnFailure: false);
            var signInResultDto = Mapper.Map<SignInResultDto>(result);
            return signInResultDto;
        }
    }
}
