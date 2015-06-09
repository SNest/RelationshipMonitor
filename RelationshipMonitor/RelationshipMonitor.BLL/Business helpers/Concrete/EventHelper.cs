using System.Collections.Generic;
using Ninject;
using RelationshipMonitor.BLL.Business_helpers.Abstract;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.DAL.Repositories.Abstract;

namespace RelationshipMonitor.BLL.Business_helpers.Concrete
{
    public class EventHelper : IEventHelper
    {
        private readonly IEventRepository repository;

        public EventHelper()
        {
            IKernel kernel = new StandardKernel(new Bindings());
            repository = kernel.Get<IEventRepository>();
        }
        public void Create(Event user)
        {
            repository.Create(user);
        }

        public void Edit(Event user)
        {
            repository.Edit(user);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Event GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return repository.GetAll();
        }
    }
}
