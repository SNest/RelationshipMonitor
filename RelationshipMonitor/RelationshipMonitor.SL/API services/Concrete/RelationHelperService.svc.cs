using System;
using System.Collections.Generic;
using RelationshipMonitor.BLL.Business_helpers.Concrete;
using RelationshipMonitor.BOL.Entities;
using RelationshipMonitor.SL.API_services.Abstract;

namespace RelationshipMonitor.SL.API_services.Concrete
{
    public class RelationHelperService : IRelationHelperService
    {
        private readonly RelationHelper relationHelper;

        RelationHelperService()
        {
            relationHelper = new RelationHelper();
        }

        public void Create(Relation relation)
        {
            relationHelper.Create(relation);
        }

        public void Edit(Relation relation)
        {
            relationHelper.Edit(relation);
        }

        public void Delete(string id)
        {
            relationHelper.Delete(Convert.ToInt32(id));
        }

        public Relation GetById(string id)
        {
            return relationHelper.GetById(Convert.ToInt32(id)); ;
        }

        public IEnumerable<Relation> GetAll()
        {
            return relationHelper.GetAll();
        }
    }
}
