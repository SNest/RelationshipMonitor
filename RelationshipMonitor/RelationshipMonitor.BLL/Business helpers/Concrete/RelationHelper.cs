using System.Collections.Generic;
using Ninject;
using RelationshipMonitor.BLL.Business_helpers.Abstract;
using RelationshipMonitor.BLL.Infrastructure;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.DAL.Repositories.Abstract;

namespace RelationshipMonitor.BLL.Business_helpers.Concrete
{
    public class RelationHelper : IRelationHelper
    {
        private readonly IRelationRepository repository;

        public RelationHelper()
        {
            IKernel kernel = new StandardKernel(new Bindings());
            repository = kernel.Get<IRelationRepository>();
        }
        public void Create(Relation relation)
        {
            repository.Create(relation);
        }

        public void Edit(Relation relation)
        {
            repository.Edit(relation);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Relation GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Relation> GetAll()
        {
            return repository.GetAll();
        }
    }
}
