using Contract.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Mapping
{
    public class UserProfileMapping : BaseMapping
    {
        public override void Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().ToTable("extendUserProfile").HasKey(x => x.Id);
        }
    }
}
