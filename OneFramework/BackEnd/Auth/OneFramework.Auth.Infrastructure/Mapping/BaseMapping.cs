using Microsoft.EntityFrameworkCore;

namespace OneFramework.Auth.Infrastructure.Mapping
{
    public abstract class BaseMapping
    {
        public abstract void Mapping(ModelBuilder modelBuilder);
    }
}
