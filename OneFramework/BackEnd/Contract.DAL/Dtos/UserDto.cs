using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class UserDto : BaseDto
    {
        public Guid RoleId { get; set; }
        public bool Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual RoleDto Role { get; set; }
        public virtual IList<UserProfileDto> UserProfiles { get; set; }
    }
}
