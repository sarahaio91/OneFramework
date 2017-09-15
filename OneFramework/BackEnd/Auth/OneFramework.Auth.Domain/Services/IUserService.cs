using System;
using OneFramework.Auth.Domain.Dtos;

namespace OneFramework.Auth.Domain.Services
{
    public interface IUserService
    {
        UserProfileDto GetUserProfileByUserId(Guid id);
        UserDto Login(UserDto userDto);
        UserDto Register(UserDto userDto);
    }
}
