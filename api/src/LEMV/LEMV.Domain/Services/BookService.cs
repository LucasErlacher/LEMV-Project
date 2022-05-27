using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(INotificator notificator, IBookRepository bookRepository) : base(notificator)
        {
            _bookRepository = bookRepository;
        }

        public Book Create(Book entity)
        {
            return _bookRepository.Add(entity); ;
        }

        public Book Update(Book entity)
        {
            return _bookRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);

            return;
        }
    }
}
