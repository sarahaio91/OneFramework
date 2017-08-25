using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mapping
{
    public class UserMapping : BaseMapping
    {
        public override void Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("extendUser").HasKey(x => x.Id);
        }
    }
}
