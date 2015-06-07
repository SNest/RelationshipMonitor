using System.Collections.Generic;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.BLL.Business_helpers.Abstract
{
    public interface IRelationHelper : IEntityHelper
    {
        void Create(Relation relation);

        void Edit(Relation relation);

        Relation GetById(int id);

        IEnumerable<Relation> GetAll();
    }
}