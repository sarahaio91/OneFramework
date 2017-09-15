using System.Collections.Generic;

namespace OneFramework.Hunter.Domain.Entities.User
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IList<global::OneFramework.Hunter.Domain.Entities.User.User> Users { get; set; }
    }
}
