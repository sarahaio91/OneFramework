using Contract.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contract.DAL.Data
{
    public abstract class JobLineDbContextAbstract : IdentityDbContext<ApplicationUser>
    {
        protected JobLineDbContextAbstract(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
