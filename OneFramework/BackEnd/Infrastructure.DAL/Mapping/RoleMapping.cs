using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mapping
{
    public class RoleMapping : BaseMapping
    {
        public override void Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("extendRole").HasKey(x => x.Id);
        }
    }
}
