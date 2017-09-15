using Microsoft.EntityFrameworkCore;

namespace OneFramework.Hunter.Infrastructure.Mapping
{
    public abstract class BaseMapping
    {
        public abstract void Mapping(ModelBuilder modelBuilder);
    }
}
