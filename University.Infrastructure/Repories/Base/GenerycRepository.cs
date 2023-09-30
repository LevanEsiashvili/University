using Microsoft.EntityFrameworkCore;
using University.Domain.Contracts.Repositories.Base;
using University.Infrastructure.Database;

namespace University.Infrastructure.Repories.Base
{
    public class GenerycRepository<TEntity> : IGenerycRepository<TEntity> where TEntity : class
    {
        public UniversityDbContext Context { get; set; }

        public GenerycRepository(UniversityDbContext context)
        {
            Context = context;
        }

        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return Context.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public void CreateMany(List<TEntity> entities)
        {

            Context.Set<TEntity>().AddRange(entities);
        }

        public void UpdateMany(List<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
        }

        public void DeleteMany(List<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
