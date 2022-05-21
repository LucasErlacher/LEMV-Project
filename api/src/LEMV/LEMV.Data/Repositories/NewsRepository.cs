using LEMV.Data.Context;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LEMV.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly IFakeDatabase _fake;

        public NewsRepository(ApplicationDbContext dbContext, IFakeDatabase fake)
        {
            _fake = fake;
        }

        public ICollection<News> GetAll()
        {
            return _fake.News.ToList();
        }

        public News GetById(int id)
        {
            return _fake.News.SingleOrDefault(x => x.Id == id);
        }

        public void Create(News entity)
        {
            _fake.News.Add(entity);
        }

        public int GenerateId()
        {
            var obj = _fake.News.LastOrDefault();
            var id = obj == null ? 1 : obj.Id + 1;
            return id;
        }
    }
}