using Contract.DAL.Data;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class JobLineDbContext : JobLineDbContextAbstract
    {
        public JobLineDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new RoleMapping().Mapping(modelBuilder);
            new UserMapping().Mapping(modelBuilder);
            new UserProfileMapping().Mapping(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
