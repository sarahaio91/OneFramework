using System.Collections.Generic;

namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
