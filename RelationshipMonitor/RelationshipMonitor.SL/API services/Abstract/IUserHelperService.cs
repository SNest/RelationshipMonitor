using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.SL.API_services.Abstract
{
    [ServiceContract]
    public interface IUserHelperService
    {
        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "api/user/create")]
        void Create(User user);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "api/user/edit")]
        void Edit(User user);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "api/user/delete/{id}")]
        void Delete(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "api/user/get/{id}")]
        User GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "api/user/getall")]
        IEnumerable<User> GetAll();
    }
}
