using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;

namespace LEMV.Data.Repositories
{
    public class PaperRepository : Repository<Paper>, IPaperRepository
    {
        private const string COLLECTION_NAME = "papers";

        public PaperRepository(LiteDatabase db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }
    }
}