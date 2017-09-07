using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public abstract class OneDbContextAbstract : IdentityDbContext<ApplicationUser>
    {
        protected OneDbContextAbstract(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
