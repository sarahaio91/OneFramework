using System.Collections.Generic;

namespace OneFramework.Auth.Domain.Dtos
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IList<UserDto> Users { get; set; }
    }
}
