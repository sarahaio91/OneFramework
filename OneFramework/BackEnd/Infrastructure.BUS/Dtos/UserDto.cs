using System;
using System.Collections.Generic;
using Contract.BUS.Dtos;

namespace Application.Dtos
{
    public class UserDto : Application.Dtos.BaseDto
    {
        public Guid RoleId { get; set; }
        public bool Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual Application.Dtos.RoleDto Role { get; set; }
        public virtual IList<UserProfileDto> UserProfiles { get; set; }
    }
}
