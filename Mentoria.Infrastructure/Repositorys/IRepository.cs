using System.Linq.Expressions;

public interface IRepository<TEntity>{
    Task Add(TEntity entity);
    Task<IQueryable<TEntity>> GetAll();
     Task<TEntity> GetById(int id);

     IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
     Task Update(TEntity entity);

    Task Remove(TEntity entity);

}