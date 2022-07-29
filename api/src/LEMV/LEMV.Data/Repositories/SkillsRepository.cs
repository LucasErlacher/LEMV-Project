using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace LEMV.Data.Repositories
{
    public class SkillsRepository : Repository<Skill>, ISkillsRepository
    {
        private const string COLLECTION_NAME = "skills";

        public SkillsRepository(LiteDatabase db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }

        public override Skill Add(Skill entity)
        {
            var dbSkills = _dbSet;
            var dbAbilities = _db.GetCollection<Ability>("abilities");

            dbAbilities.Insert(entity.Abilities);

            dbSkills.Insert(entity);

            return entity;
        }

        public override Skill GetById(int id)
        {
            var result = _dbSet.Include(x => x.Abilities).FindOne(x => x.Id == id);

            return result;
        }

        public override IEnumerable<Skill> GetAll()
        {
            return _dbSet.Include(x => x.Abilities).Query().ToList();
        }

        public override void Delete(object id)
        {
            var dbSkills = _dbSet;
            var dbAbilities = _db.GetCollection<Ability>("abilities");

            var idsAbilities = GetById((int)id).Abilities.Select(x => x.Id);

            dbAbilities.DeleteMany(x => idsAbilities.Contains(x.Id));
            dbSkills.Delete(new BsonValue(id));
        }


        public override Skill Update(Skill entity)
        {
            var dbAbilities = _db.GetCollection<Ability>("abilities");

            var originalEntity = GetById(entity.Id);

            var excludeAbilities = originalEntity.Abilities.Where(x => !entity.Abilities.Select(y => y.Id).Contains(x.Id)).Select(x => x.Id);
            var upsertAbilities = entity.Abilities;

            dbAbilities.DeleteMany(x => excludeAbilities.Contains(x.Id));
            dbAbilities.Upsert(upsertAbilities);

            _dbSet.Update(entity);

            return GetById(entity.Id);
        }
    }
}