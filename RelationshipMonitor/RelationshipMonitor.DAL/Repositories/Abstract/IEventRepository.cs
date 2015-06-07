using System.Collections.Generic;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.DAL.Repositories.Abstract
{
    public interface IEventRepository : IEntityRepository
    {
        void Create(Event e);

        void Edit(Event e);

        Event GetById(int id);

        IEnumerable<Event> GetAll();
    }
}