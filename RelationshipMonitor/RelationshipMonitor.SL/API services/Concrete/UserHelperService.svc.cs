using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using RelationshipMonitor.BLL.Business_helpers.Concrete;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.SL.API_services.Abstract;


namespace RelationshipMonitor.SL.API_services.Concrete
{
    public class UserHelperService : IUserHelperService
    {
        
        private readonly UserHelper userHelper;

        UserHelperService()
        {
            userHelper = new UserHelper();
        }

        public void Create(User user)
        {
            userHelper.Create(user);
        }

        public void Edit(User user)
        {
            userHelper.Edit(user);
        }

        public void Delete(string id)
        {
            userHelper.Delete(Convert.ToInt32(id));
        }

        public User GetById(string id)
        {
            return userHelper.GetById(Convert.ToInt32(id));;
        }

        public IEnumerable<User> GetAll()
        {
            return userHelper.GetAll();
        }
        
    }
}
