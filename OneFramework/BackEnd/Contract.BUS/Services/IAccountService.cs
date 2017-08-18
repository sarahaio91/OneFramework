﻿using System.Threading.Tasks;
using Contract.BUS.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Contract.BUS.Services
{
    public interface IAccountService
    {
        Task<SignInResult> Login(LoginDto loginDto);
    }
}
