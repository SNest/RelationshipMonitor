using System;
using System.Collections.Generic;
using RelationshipMonitor.BLL.Business_helpers.Concrete;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.SL.API_services.Abstract;

namespace RelationshipMonitor.SL.API_services.Concrete
{
    public class EventHelperService : IEventHelperService
    {
        private readonly EventHelper eHelper;

        EventHelperService()
        {
            eHelper = new EventHelper();
        }

        public void Create(Event e)
        {
            eHelper.Create(e);
        }

        public void Edit(Event e)
        {
            eHelper.Edit(e);
        }

        public void Delete(string id)
        {
            eHelper.Delete(Convert.ToInt32(id));
        }

        public Event GetById(string id)
        {
            return eHelper.GetById(Convert.ToInt32(id)); ;
        }

        public IEnumerable<Event> GetAll()
        {
            return eHelper.GetAll();
        }
    }
}
