using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneFramework.Hunter.Domain.Entities.User;

namespace OneFramework.Hunter.Domain.Data
{
    public abstract class OneDbContextAbstract : IdentityDbContext<ApplicationUser>
    {
        protected OneDbContextAbstract(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
