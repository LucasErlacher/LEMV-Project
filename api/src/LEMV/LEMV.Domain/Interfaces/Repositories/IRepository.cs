using LEMV.Domain.Entities;
using System.Collections.Generic;

namespace LEMV.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(object id);
    }
}
