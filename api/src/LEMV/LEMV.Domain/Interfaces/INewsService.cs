using LEMV.Domain.Entities;

namespace LEMV.Domain.Interfaces
{
    public interface INewsService
    {
        News Create(News entity);
        News Update(News entity);
        void Delete(int id);
    }
}
