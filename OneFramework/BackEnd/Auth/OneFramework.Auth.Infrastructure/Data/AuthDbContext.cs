using Microsoft.EntityFrameworkCore;
using OneFramework.Auth.Domain.Data;
using OneFramework.Auth.Infrastructure.Mapping;

namespace OneFramework.Auth.Infrastructure.Data
{
    public class AuthDbContext : AuthDbContextAbstract
    {
        public AuthDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new RoleMapping().Mapping(modelBuilder);
            //new UserMapping().Mapping(modelBuilder);
            //new UserProfileMapping().Mapping(modelBuilder);
            new HomeMapping().Mapping(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
