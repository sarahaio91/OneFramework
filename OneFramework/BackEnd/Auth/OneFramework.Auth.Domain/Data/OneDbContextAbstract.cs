using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneFramework.Auth.Domain.Entities.User;

namespace OneFramework.Auth.Domain.Data
{
    public abstract class OneDbContextAbstract : IdentityDbContext<ApplicationUser>
    {
        protected OneDbContextAbstract(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
