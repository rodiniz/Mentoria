using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Mentoria.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly DbContext _db;
    private readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(DbContext db)
    {
        _db = db;
        _dbSet = db.Set<TEntity>();
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        _dbSet.Add(entity);
        await SaveChanges();
        return entity;
    }

    public async Task<IQueryable<TEntity>> GetAll()
    {
        return await Task.FromResult( _dbSet.AsNoTracking());
    }
    public async Task<TEntity?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }


    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate);
    }

       
    public async Task Update(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveChanges();
    }

    public async Task Remove(int id)
    {
        _dbSet.Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    public async Task Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
        await SaveChanges();
    }

    private async Task<int> SaveChanges()
    {
        return await _db.SaveChangesAsync();
    }      
}