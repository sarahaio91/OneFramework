using System;
using System.Threading.Tasks;
using Domain.Auth;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using WebApi.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("v1/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSender;
        private readonly ITokenService _tokenService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAccountService accountService,
            ILogger<AccountController> logger,
            IEmailSender emailSender,
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _tokenService = tokenService;
        }

        // GET: v1/api/ping
        [HttpGet]
        [Authorize(Policy = AuthTokenOption.TokenType)]
        public JsonResult Get()
        {
            var returnData = new PingModel()
            {
                Status = "running",
                StatusCode = 200
            };
            return Json(returnData);
        }

        // POST v1/account/login
        [HttpPost]
        public async Task<JsonResult> Login([FromBody]LoginApiModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent:true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");

                var requestAt = DateTime.Now;
                var expiresIn = requestAt + AuthTokenOption.ExpiresSpan;
                var token = _tokenService.GenerateToken(model.Email, expiresIn);

                return Json(new Result()
                {
                    State = RequestState.Success,
                    Message = "User logged in.",
                    Data = new UserData()
                    {
                        RequestAt = requestAt,
                        ExpireIn = AuthTokenOption.ExpiresSpan.TotalSeconds,
                        TokenType = AuthTokenOption.TokenType,
                        Token = token
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

        // POST v1/account/register
        [HttpPost]
        public async Task<JsonResult> Register([FromBody]RegisterApiModel model)
        {
            var user = new ApplicationUser
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                await _signInManager.SignInAsync(user, isPersistent: false);

                var requestAt = DateTime.Now;
                var expiresIn = requestAt + AuthTokenOption.ExpiresSpan;
                var token = _tokenService.GenerateToken(user.Email, expiresIn);

                return Json(new Result()
                {
                    State = RequestState.Success,
                    Message = "User registered and logged in.",
                    Data = new UserData()
                    {
                        RequestAt = requestAt,
                        ExpireIn = AuthTokenOption.ExpiresSpan.TotalSeconds,
                        TokenType = AuthTokenOption.TokenType,
                        Token = token
                    }
                });
            }

            // If we got this far, something failed
            return Json(new Result
            {
                State = RequestState.Failed,
                Message = "Create user failed"
            });
        }
    }
}
