namespace DotnetLabs.Data;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> GetAll();
    Task<TEntity> Get(int id);
    Task<TEntity> GetByTitle(string title);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity> Delete(int id);
}
