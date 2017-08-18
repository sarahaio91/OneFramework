using Contract.DAL.Data;
using Infrastructure.DAL.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Data
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
