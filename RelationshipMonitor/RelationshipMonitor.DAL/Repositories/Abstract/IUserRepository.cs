using System.Collections.Generic;
using System.Linq;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.DAL.Repositories.Abstract
{
    public interface IUserRepository : IEntityRepository
    {
        void Create(User user);

        void Edit(User user);

        User GetById(int id);

        IEnumerable<User> GetAll();
    }
}