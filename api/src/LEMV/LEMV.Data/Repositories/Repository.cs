using LEMV.Data.Context;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LEMV.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly DbContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public virtual async Task Delete(params object[] id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
