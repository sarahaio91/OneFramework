using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mapping
{
    public abstract class BaseMapping
    {
        public abstract void Mapping(ModelBuilder modelBuilder);
    }
}
