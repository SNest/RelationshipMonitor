using System;
using System.Collections.Generic;
using RelationshipMonitor.BLL.Business_helpers.Concrete;
using RelationshipMonitor.SL.API_services.Abstract;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.SL.API_services.Concrete
{
    public class ActivityHelperService : IActivityHelperService
    {
        private readonly ActivityHelper activityHelper;

        ActivityHelperService()
        {
            activityHelper = new ActivityHelper();
        }

        public void Create(Activity activity)
        {
            activityHelper.Create(activity);
        }

        public void Edit(Activity activity)
        {
            activityHelper.Edit(activity);
        }

        public void Delete(string id)
        {
            activityHelper.Delete(Convert.ToInt32(id));
        }

        public Activity GetById(string id)
        {
            return activityHelper.GetById(Convert.ToInt32(id)); ;
        }

        public IEnumerable<Activity> GetAll()
        {
            return activityHelper.GetAll();
        }
    }
}
