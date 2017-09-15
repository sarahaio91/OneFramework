using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OneFramework.Auth.Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public ICollection<OneFramework.Auth.Domain.Entities.Home.Home> Homes { get; set; }
    }
}
