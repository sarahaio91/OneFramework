using Microsoft.EntityFrameworkCore;
using OneFramework.Auth.Domain.Entities.User;

namespace OneFramework.Auth.Infrastructure.Mapping
{
    public class RoleMapping : BaseMapping
    {
        public override void Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("extendRole").HasKey(x => x.Id);
        }
    }
}
