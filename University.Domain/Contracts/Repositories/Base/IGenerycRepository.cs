namespace University.Domain.Contracts.Repositories.Base
{
    public interface IGenerycRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void CreateMany(List<TEntity> entities);
        void UpdateMany(List<TEntity> entities);
        void DeleteMany(List<TEntity> entities);

        IQueryable<TEntity> GetQueryable();

    }
}
