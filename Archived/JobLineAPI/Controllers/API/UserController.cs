using System;
using System.Web.Helpers;
using System.Web.Http;
using AutoMapper;
using Contract.BUS.BusinessLogics;
using Contract.BUS.Dtos;
using JobLineAPI.Models;

namespace JobLineAPI.Controllers.API
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/user/5
        [Route("{id}")]
        public UserProfileModel Get(Guid id)
        {
            var user = _userService.GetUserProfileByUserId(id);
            return Mapper.Map<UserProfileModel>(user) ?? new UserProfileModel();
        }

        // POST api/user/login
        [Route("login")]
        public UserModel Login([FromBody]UserModel user)
        {
            var userDto = Mapper.Map<UserDto>(user);
            var isLogin = _userService.Login(userDto);
            var verifyPassword = Crypto.VerifyHashedPassword(isLogin.Password,userDto.Password);
            return verifyPassword == true ? Mapper.Map<UserModel>(isLogin) : null;
        }

        // POST api/user/register
        [Route("register")]
        public void Register([FromBody]UserModel user)
        {
            var userDto = Mapper.Map<UserDto>(user);
            //Encrypt password
            var hashPassword = Crypto.HashPassword(userDto.Password);
            userDto.Password = hashPassword;
            var isLogin = _userService.Register(userDto);
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
