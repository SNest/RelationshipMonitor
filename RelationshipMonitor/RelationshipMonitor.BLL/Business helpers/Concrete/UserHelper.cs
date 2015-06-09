using System.Collections.Generic;
using Ninject;
using RelationshipMonitor.BLL.Business_helpers.Abstract;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.DAL.Repositories.Abstract;

namespace RelationshipMonitor.BLL.Business_helpers.Concrete
{
    public class UserHelper : IUserHelper
    {
        private readonly IUserRepository repository;

        public UserHelper()
        {
            IKernel kernel = new StandardKernel(new Bindings());
            repository = kernel.Get<IUserRepository>();
        }
        public void Create(User user)
        {
            repository.Create(user);
        }

        public void Edit(User user)
        {
            repository.Edit(user);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public User GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }
    }
}
