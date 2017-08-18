using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Mapping
{
    public abstract class BaseMapping
    {
        public abstract void Mapping(ModelBuilder modelBuilder);
    }
}
