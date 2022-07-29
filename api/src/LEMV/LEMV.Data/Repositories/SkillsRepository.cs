using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;

namespace LEMV.Data.Repositories
{
    public class SkillsRepository : Repository<Skill>, ISkillsRepository
    {
        private const string COLLECTION_NAME = "skills";

        public SkillsRepository(LiteDatabase db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }
    }
}