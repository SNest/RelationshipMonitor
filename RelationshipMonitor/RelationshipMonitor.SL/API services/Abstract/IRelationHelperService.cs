using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.SL.API_services.Abstract
{
    [ServiceContract]
    public interface IRelationHelperService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/relation/create")]
        void Create(Relation relation);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/relation/edit")]
        void Edit(Relation relation);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/relation/delete/{id}")]
        void Delete(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/relation/get/{id}")]
        Relation GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/relation/getall")]
        IEnumerable<Relation> GetAll();
    }
}
