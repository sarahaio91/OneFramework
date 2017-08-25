using System;
using Domain.Dtos;

namespace Domain.Services
{
    public interface IUserService
    {
        UserProfileDto GetUserProfileByUserId(Guid id);
        UserDto Login(UserDto userDto);
        UserDto Register(UserDto userDto);
    }
}
