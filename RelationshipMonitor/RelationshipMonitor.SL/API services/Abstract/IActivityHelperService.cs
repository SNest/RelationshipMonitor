using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.SL.API_services.Abstract
{
    [ServiceContract] 
    public interface IActivityHelperService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/activity/create")]
        void Create(Activity activity);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/activity/edit")]
        void Edit(Activity activity);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/activity/delete/{id}")]
        void Delete(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/activity/get/{id}")]
        Activity GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/activity/getall")]
        IEnumerable<Activity> GetAll();
    }
}
