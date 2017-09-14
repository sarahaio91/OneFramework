using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public ICollection<Home.Home> Homes { get; set; }
    }
}
