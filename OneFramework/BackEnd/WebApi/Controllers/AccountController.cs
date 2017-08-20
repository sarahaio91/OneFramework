using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using Contract.BUS.Dtos;
using Contract.BUS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebApi.Auth;
using WebApi.Models;
using WebApi.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("v1/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ILogger _logger;

        public AccountController(
            IAccountService accountService,
            ILogger<AccountController> logger
            )
        {
            _accountService = accountService;
            _logger = logger;
        }

        // GET: v1/api/ping
        [HttpGet]
        [Authorize(Policy = "Bearer")]
        public JsonResult Get()
        {
            var returnData = new PingModel()
            {
                Status = "running",
                StatusCode = 200
            };
            return Json(returnData);
        }

        // POST api/values
        [HttpPost]
        public JsonResult Login([FromBody]LoginModel model)
        {
            var loginDto = Mapper.Map<LoginDto>(model);
            var result = _accountService.Login(loginDto).Result;

            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");

                var requestAt = DateTime.Now;
                var expiresIn = requestAt + AuthTokenOption.ExpiresSpan;
                var token = GenerateToken(model, expiresIn);

                return Json(new Result()
                {
                    State = RequestState.Success,
                    Message = "User logged in.",
                    Data = new
                    {
                        requertAt = requestAt,
                        expiresIn = AuthTokenOption.ExpiresSpan.TotalSeconds,
                        tokeyType = AuthTokenOption.TokenType,
                        accessToken = token
                    }
                });
            }
            //if (result.RequiresTwoFactor)
            //{
            //    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
            //}
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return Json(new Result
                {
                    State = RequestState.Failed,
                    Message = "User account locked out."
                });
            }
            else
            {
                return Json(new Result
                {
                    State = RequestState.Failed,
                    Message = "Invalid login attempt."
                });
            }
        }

        #region private functions

        private string GenerateToken(LoginModel user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Email, "TokenAuth")
                , new[] {
                    new Claim("Email", user.Email)
                }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = AuthTokenOption.Issuer,
                Audience = AuthTokenOption.Audience,
                SigningCredentials = AuthTokenOption.SigningCredentials,
                Subject = identity,
                Expires = expires
            });
            return handler.WriteToken(securityToken);
        }

        #endregion
    }
}
