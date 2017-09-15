using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OneFramework.Hunter.Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public ICollection<Hunter.Domain.Entities.Home.Home> Homes { get; set; }
    }
}
