using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(SignInManager<ApplicationUser> signInManager)
        {
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
