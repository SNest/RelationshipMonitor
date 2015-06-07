using System.Collections.Generic;
using System.Linq;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.DAL.Repositories.Abstract
{
    public interface IRelationRepository : IEntityRepository
    {
        void Create(Relation relation);

        void Edit(Relation relation);

        Relation GetById(int id);

        IEnumerable<Relation> GetAll();
    }
}