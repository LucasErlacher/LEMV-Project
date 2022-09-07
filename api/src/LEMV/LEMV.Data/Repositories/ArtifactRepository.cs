using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;

namespace LEMV.Data.Repositories
{
    public class ArtifactRepository : Repository<Artifact>, IArtifactRepository
    {
        private const string COLLECTION_NAME = "artifacts";

        public ArtifactRepository(LiteDatabase db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }
    }
}