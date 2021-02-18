using LEMV.Data.Context;
using LEMV.Domain.Entities;
using System.Linq;

namespace LEMV.Data.Repositories
{
    public class NewsRepository : Repository<News>
    {
        public NewsRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public object GetAll()
        {
            return _dbSet.Take(1000).ToList();
        }
    }
}