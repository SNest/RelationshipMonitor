using System;
using System.Collections.Generic;
using System.Data.Entity;
using NLog;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.DAL.Repositories.Abstract;

namespace RelationshipMonitor.DAL.Repositories.Concrete
{
    public class EFActivityRepository : IActivityRepository
    {
        private static Logger logger;
        private readonly EFDbContext context;

        public EFActivityRepository()
        {
            logger = LogManager.GetCurrentClassLogger();
            context = new EFDbContext();
        }

        public void Create(Activity activity)
        {
            try
            {
                context.Activities.Add(activity);
                logger.Info("Activity was added to the context");
                Save();
            }
            catch (Exception exception)
            {
                logger.Error("Activity was not added to the context");
                logger.Trace(exception.StackTrace);
            }
        }

        public void Edit(Activity activity)
        {
            try
            {
                context.Entry(activity).State = EntityState.Modified;
                logger.Info("Activity changes was added to the context");
                Save();
            }
            catch (Exception exception)
            {
                logger.Error("Activity changes was not added to the context");
                logger.Trace(exception.StackTrace);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var c = GetById(id);
                context.Activities.Remove(c);
                logger.Info("Changes was saved to the database");
                Save();
            }
            catch (Exception exception)
            {
                logger.Info("Changes was not saved to the database");
                logger.Trace(exception.StackTrace);
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
                logger.Info("Activity changes was saved to the database");
            }
            catch (Exception exception)
            {
                logger.Info("Activity changes was not saved to the database");
                logger.Trace(exception.StackTrace);
            }
        }

        public Activity GetById(int id)
        {
            var c = new Activity();
            try
            {
                c = context.Activities.Find(id);
                logger.Info("Activity was got from the context");
            }
            catch (Exception exception)
            {
                logger.Error("Activity was not got from the context");
                logger.Trace(exception.StackTrace);
            }
            return c;
        }

        public IEnumerable<Activity> GetAll()
        {
            IEnumerable<Activity> cs = null;
            try
            {
                cs = context.Activities;
                logger.Info("Activity was got from the context");
            }
            catch (Exception exception)
            {
                logger.Error("Activity was not got from the context");
                logger.Trace(exception.StackTrace);
            }
            return cs;
        }
    }
}