using LEMV.Domain.Entities;

namespace LEMV.Domain.Interfaces
{
    public interface IBookService
    {
        Book Create(Book entity);
        Book Update(Book entity);
        void Delete(int id);
    }
}
