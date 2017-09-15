using Microsoft.EntityFrameworkCore;
using OneFramework.Hunter.Domain.Entities.User;

namespace OneFramework.Hunter.Infrastructure.Mapping
{
    public class RoleMapping : BaseMapping
    {
        public override void Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("extendRole").HasKey(x => x.Id);
        }
    }
}
