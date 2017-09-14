using Domain.Data;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
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
