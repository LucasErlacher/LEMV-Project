using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;

namespace LEMV.Data.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private const string COLLECTION_NAME = "materials";

        public MaterialRepository(LiteDatabase db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }
    }
}