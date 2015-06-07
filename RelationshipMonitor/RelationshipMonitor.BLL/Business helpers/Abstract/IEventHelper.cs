using System.Collections.Generic;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.BLL.Business_helpers.Abstract
{
    public interface IEventHelper : IEntityHelper
    {
        void Create(Event e);

        void Edit(Event e);

        Event GetById(int id);

        IEnumerable<Event> GetAll();
    }
}