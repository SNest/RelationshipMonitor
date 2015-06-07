using System;
using System.Collections.Generic;
using System.Data.Entity;
using NLog;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.DAL.Repositories.Abstract;

namespace RelationshipMonitor.DAL.Repositories.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private static Logger logger;
        private readonly EFDbContext context;

        public EFUserRepository()
        {
            logger = LogManager.GetCurrentClassLogger();
            context = new EFDbContext();
        }

        public void Create(User user)
        {
            try
            {
                context.Users.Add(user);
                logger.Info("User was added to the context");
                Save();
            }
            catch (Exception exception)
            {
                logger.Error("User was not added to the context");
                logger.Trace(exception.StackTrace);
            }
        }

        public void Edit(User user)
        {
            try
            {
                context.Entry(user).State = EntityState.Modified;
                logger.Info("User changes was added to the context");
                Save();
            }
            catch (Exception exception)
            {
                logger.Error("User changes was not added to the context");
                logger.Trace(exception.StackTrace);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var u = GetById(id);
                context.Users.Remove(u);
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
                logger.Info("User changes was saved to the database");
            }
            catch (Exception exception)
            {
                logger.Info("User changes was not saved to the database");
                logger.Trace(exception.StackTrace);
            }
        }

        public User GetById(int id)
        {
            var u = new User();
            try
            {
                u = context.Users.Find(id);
                logger.Info("User was got from the context");
            }
            catch (Exception exception)
            {
                logger.Error("User was not got from the context");
                logger.Trace(exception.StackTrace);
            }
            return u;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> us = null;
            try
            {
                us = context.Users;
                logger.Info("User was got from the context");
            }
            catch (Exception exception)
            {
                logger.Error("User was not got from the context");
                logger.Trace(exception.StackTrace);
            }
            return us;
        }
    }
}
