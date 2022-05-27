using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;
using System;
using System.Collections.Generic;

namespace LEMV.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : Entity
    {
        protected string _collection;

        protected LiteDatabase _db;
        protected ILiteCollection<TEntity> _dbSet;

        protected Repository(LiteDatabase dbContext)
        {
            _db = dbContext;
        }

        protected void DefineCollection(string collectionName)
        {
            _collection = collectionName;
            _dbSet = _db.GetCollection<TEntity>(_collection);
        }

        public virtual TEntity Add(TEntity entity)
        {
            _dbSet.Insert(entity);

            return GetById(entity.Id);
        }

        public virtual void Delete(object id)
        {
            _dbSet.Delete(new BsonValue(id));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.Query().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.FindOne(x => x.Id == id);
        }

        public virtual TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);

            return GetById(entity.Id);
        }

        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
    }
}
