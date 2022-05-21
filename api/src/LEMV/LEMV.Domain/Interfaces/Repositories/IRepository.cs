using LEMV.Domain.Entities;
using System.Threading.Tasks;

namespace LEMV.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task Delete(params object[] id);
    }
}
