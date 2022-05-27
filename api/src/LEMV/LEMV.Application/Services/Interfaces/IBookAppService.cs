using LEMV.Application.ViewModels;

namespace LEMV.Domain.Interfaces
{
    public interface IBookAppService
    {
        BookViewModel CreateBook(BookViewModel news);
        BookViewModel UpdateBook(BookViewModel news);
        void DeleteBook(int id);
    }
}
