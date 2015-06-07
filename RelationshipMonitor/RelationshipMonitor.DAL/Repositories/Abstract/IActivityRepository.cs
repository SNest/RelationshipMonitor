using System.Collections.Generic;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.DAL.Repositories.Abstract
{
    public interface IActivityRepository : IEntityRepository
    {
        void Create(Activity activity);

        void Edit(Activity activity);

        Activity GetById(int id);

        IEnumerable<Activity> GetAll();

    }
}