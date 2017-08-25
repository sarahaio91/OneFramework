using System.Collections.Generic;
using Contract.BUS.Dtos;

namespace Application.Dtos
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IList<UserDto> Users { get; set; }
    }
}
