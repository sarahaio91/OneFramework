using System.Collections.Generic;

namespace JobLineAPI.Models
{
    public class RoleModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<UserModel> Users { get; set; }
    }
}