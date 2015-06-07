using System.Collections.Generic;
using Ninject;
using RelationshipMonitor.BLL.Business_helpers.Abstract;
using RelationshipMonitor.BLL.Infrastructure;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.DAL.Repositories.Abstract;

namespace RelationshipMonitor.BLL.Business_helpers.Concrete
{
    public class ActivityHelper : IActivityHelper
    {
        private readonly IActivityRepository repository;

        public ActivityHelper()
        {
            IKernel kernel = new StandardKernel(new Bindings());
            repository = kernel.Get<IActivityRepository>();
        }
        public void Create(Activity activity)
        {
            repository.Create(activity);
        }

        public void Edit(Activity activity)
        {
            repository.Edit(activity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Activity GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return repository.GetAll();
        }
    }
}
