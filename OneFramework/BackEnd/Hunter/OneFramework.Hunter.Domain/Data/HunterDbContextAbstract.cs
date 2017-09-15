using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneFramework.Hunter.Domain.Entities.User;

namespace OneFramework.Hunter.Domain.Data
{
    public abstract class HunterDbContextAbstract : IdentityDbContext<ApplicationUser>
    {
        protected HunterDbContextAbstract(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
