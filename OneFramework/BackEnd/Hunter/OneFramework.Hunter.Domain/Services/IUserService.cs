using System;
using OneFramework.Hunter.Domain.Dtos;

namespace OneFramework.Hunter.Domain.Services
{
    public interface IUserService
    {
        UserProfileDto GetUserProfileByUserId(Guid id);
        UserDto Login(UserDto userDto);
        UserDto Register(UserDto userDto);
    }
}
