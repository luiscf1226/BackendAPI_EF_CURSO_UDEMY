namespace Backend.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();
        IEnumerable<TEntity> Search(Func<TEntity, bool> filter);
    }
}
