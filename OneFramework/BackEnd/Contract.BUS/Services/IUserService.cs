using System;
using Contract.BUS.Dtos;

namespace Contract.BUS.Services
{
    public interface IUserService
    {
        UserProfileDto GetUserProfileByUserId(Guid id);
        UserDto Login(UserDto userDto);
        UserDto Register(UserDto userDto);
    }
}
