using System.Linq.Expressions;

namespace Mentoria.Infrastructure.Repositories;

public interface IRepository<TEntity>{
    Task<TEntity> Add(TEntity entity);
    Task<IQueryable<TEntity>> GetAll();
    Task<TEntity?> GetById(int id);

    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    Task Update(TEntity entity);

    Task Remove(int id);

}