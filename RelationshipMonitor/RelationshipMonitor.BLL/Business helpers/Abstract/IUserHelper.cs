using System.Collections.Generic;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.BLL.Business_helpers.Abstract
{
    public interface IUserHelper : IEntityHelper
    {
        void Create(User user);

        void Edit(User user);

        User GetById(int id);

        IEnumerable<User> GetAll();
    }
}