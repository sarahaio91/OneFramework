using Microsoft.EntityFrameworkCore;
using OneFramework.Hunter.Domain.Entities.Home;

namespace OneFramework.Hunter.Infrastructure.Mapping
{
    public class HomeMapping : BaseMapping
    {
        public override void Mapping(ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<Home>();
            entityTypeBuilder.ToTable("extendHome");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.HasOne(x => x.CreatedBy).WithMany(x => x.Homes).HasForeignKey(x => x.CreatedById);
            //entityTypeBuilder.HasOne(x => x.UpdatedBy).WithMany(x => x.Homes).HasForeignKey(x => x.UpdatedById);
        }
    }
}
