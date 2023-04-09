using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly DbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(DbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return await Task.FromResult( DbSet.AsNoTracking());
        }
        public async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }


        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

       
        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Remove(int id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }      
    }