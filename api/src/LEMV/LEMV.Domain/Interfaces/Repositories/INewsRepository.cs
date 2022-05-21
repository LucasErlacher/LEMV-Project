using LEMV.Domain.Entities;
using System.Collections.Generic;

namespace LEMV.Domain.Interfaces.Repositories
{
    public interface INewsRepository
    {
        int GenerateId();
        ICollection<News> GetAll();
        News GetById(int id);
        void Create(News entity);
    }
}
