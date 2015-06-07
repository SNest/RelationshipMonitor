using System.Collections.Generic;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.BLL.Business_helpers.Abstract
{
    public interface IActivityHelper : IEntityHelper
    {
        void Create(Activity activity);

        void Edit(Activity activity);

        Activity GetById(int id);

        IEnumerable<Activity> GetAll();
    }
}