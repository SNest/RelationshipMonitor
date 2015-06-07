using System;
using System.Collections.Generic;
using System.Data.Entity;
using NLog;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.DAL.Repositories.Abstract;

namespace RelationshipMonitor.DAL.Repositories.Concrete
{
    public class EFEventRepository : IEventRepository
    {
        private static Logger logger;
        private readonly EFDbContext context;

        public EFEventRepository()
        {
            logger = LogManager.GetCurrentClassLogger();
            context = new EFDbContext();
        }

        public void Create(Event e)
        {
            try
            {
                context.Events.Add(e);
                logger.Info("Event was added to the context");
                Save();
            }
            catch (Exception exception)
            {
                logger.Error("Event was not added to the context");
                logger.Trace(exception.StackTrace);
            }
        }

        public void Edit(Event e)
        {
            try
            {
                context.Entry(e).State = EntityState.Modified;
                logger.Info("Event changes was added to the context");
                Save();
            }
            catch (Exception exception)
            {
                logger.Error("Event changes was not added to the context");
                logger.Trace(exception.StackTrace);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var u = GetById(id);
                context.Events.Remove(u);
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
                logger.Info("Event changes was saved to the database");
            }
            catch (Exception exception)
            {
                logger.Info("Event changes was not saved to the database");
                logger.Trace(exception.StackTrace);
            }
        }

        public Event GetById(int id)
        {
            var u = new Event();
            try
            {
                u = context.Events.Find(id);
                logger.Info("Event was got from the context");
            }
            catch (Exception exception)
            {
                logger.Error("Event was not got from the context");
                logger.Trace(exception.StackTrace);
            }
            return u;
        }

        public IEnumerable<Event> GetAll()
        {
            IEnumerable<Event> us = null;
            try
            {
                us = context.Events;
                logger.Info("Event was got from the context");
            }
            catch (Exception exception)
            {
                logger.Error("Event was not got from the context");
                logger.Trace(exception.StackTrace);
            }
            return us;
        }
    }
}