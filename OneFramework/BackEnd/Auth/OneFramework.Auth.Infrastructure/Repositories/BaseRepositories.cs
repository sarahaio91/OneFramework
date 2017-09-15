using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OneFramework.Auth.Domain.Entities;
using OneFramework.Auth.Domain.Repositories;
using OneFramework.Auth.Infrastructure.Data;

namespace OneFramework.Auth.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity, EntityEntry> where TEntity : BaseEntity
    {
        private readonly AuthDbContext context;

        public BaseRepository(AuthDbContext context)
        {
            this.context = context;
        }

        private DbSet<TEntity> GetEntities()
        {
            return context.Set<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return GetEntities().AsQueryable().SingleOrDefault(x => x.Id == id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> criteria)
        {
            return GetEntities().SingleOrDefault(criteria);
        }

        public void Update(TEntity entity)
        {
            var original = GetById(entity.Id);

            if (original != null)
            {
                GetEntities().Update(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            var original = GetById(entity.Id);
            if (original != null)
            {
                GetEntities().Remove(original);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return GetEntities().AsQueryable();
        }
        public IQueryable<TEntity> Search<TOrderBy>(Expression<Func<TEntity, bool>> criteria,
                    Expression<Func<TEntity, TOrderBy>> orderBy,
                    int pageIndex, int pageSize, out int total, SortOrder sortOrder = SortOrder.Ascending)
        {
            total = GetEntities().AsQueryable().Count();//reference

            if (sortOrder == SortOrder.Ascending)
            {
                return GetEntities().AsQueryable()
                        .Where(criteria)
                        .OrderBy(orderBy)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize);
            }
            return GetEntities().AsQueryable().Where(criteria).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public EntityEntry Insert(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            return GetEntities().Add(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

    }
}
