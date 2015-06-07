using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NLog;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.DAL.Repositories.Abstract;

namespace RelationshipMonitor.DAL.Repositories.Concrete
{
    public class EFRelationRepository : IRelationRepository
    {
        private static Logger logger;
        private readonly EFDbContext context;

        public EFRelationRepository()
        {
            logger = LogManager.GetCurrentClassLogger();
            context = new EFDbContext();
        }

        public void Create(Relation relation)
        {
            try
            {
                context.Relations.Add(relation);
                logger.Info("Relation was added to the context");
                Save();
            }
            catch (Exception exception)
            {
                logger.Error("Relation was not added to the context");
                logger.Trace(exception.StackTrace);
            }
        }

        public void Edit(Relation relation)
        {
            try
            {
                context.Entry(relation).State = EntityState.Modified;
                logger.Info("Relation changes was added to the context");
                Save();
            }
            catch (Exception exception)
            {
                logger.Error("Relation changes was not added to the context");
                logger.Trace(exception.StackTrace);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var u = GetById(id);
                context.Relations.Remove(u);
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
                logger.Info("Relation changes was saved to the database");
            }
            catch (Exception exception)
            {
                logger.Info("Relation changes was not saved to the database");
                logger.Trace(exception.StackTrace);
            }
        }

        public Relation GetById(int id)
        {
            var u = new Relation();
            try
            {
                u = context.Relations.Find(id);
                logger.Info("Relation was got from the context");
            }
            catch (Exception exception)
            {
                logger.Error("Relation was not got from the context");
                logger.Trace(exception.StackTrace);
            }
            return u;
        }

        public IEnumerable<Relation> GetAll()
        {
            IEnumerable<Relation> us = null;
            try
            {
                us = context.Relations;
                logger.Info("Relation was got from the context");
            }
            catch (Exception exception)
            {
                logger.Error("Relation was not got from the context");
                logger.Trace(exception.StackTrace);
            }
            return us;
        }
    }
}