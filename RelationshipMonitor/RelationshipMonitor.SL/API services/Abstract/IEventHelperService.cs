using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.SL.API_services.Abstract
{
    [ServiceContract]
    public interface IEventHelperService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/event/create")]
        void Create(Event e);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/event/edit")]
        void Edit(Event e);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/event/delete/{id}")]
        void Delete(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/event/get/{id}")]
        Event GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/event/getall")]
        IEnumerable<Event> GetAll();
    }
}
