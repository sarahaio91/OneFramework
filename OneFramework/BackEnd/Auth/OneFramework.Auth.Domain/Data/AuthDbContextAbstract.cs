using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneFramework.Auth.Domain.Entities.User;

namespace OneFramework.Auth.Domain.Data
{
    public abstract class AuthDbContextAbstract : IdentityDbContext<ApplicationUser>
    {
        protected AuthDbContextAbstract(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
