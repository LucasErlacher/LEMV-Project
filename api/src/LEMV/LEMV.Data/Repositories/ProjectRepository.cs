using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;

namespace LEMV.Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private const string COLLECTION_NAME = "projects";

        public ProjectRepository(LiteDatabase db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }
    }
}