using Microsoft.EntityFrameworkCore;
using OneFramework.Hunter.Domain.Data;
using OneFramework.Hunter.Infrastructure.Mapping;

namespace OneFramework.Hunter.Infrastructure.Data
{
    public class OneDbContext : OneDbContextAbstract
    {
        public OneDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
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
