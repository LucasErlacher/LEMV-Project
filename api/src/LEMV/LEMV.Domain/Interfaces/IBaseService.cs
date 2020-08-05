using LEMV.Domain.Entities;

namespace LEMV.Domain.Interfaces
{
    public interface IBaseService<T> where T : Entity
    {
        T Add(T entity);
        T Update(T entity);
        T Remove(object id);
    }
}
