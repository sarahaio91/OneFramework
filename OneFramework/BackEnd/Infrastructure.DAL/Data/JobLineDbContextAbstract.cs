using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Data
{
    public abstract class JobLineDbContextAbstract : IdentityDbContext<ApplicationUser>
    {
        protected JobLineDbContextAbstract(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
