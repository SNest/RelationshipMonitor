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
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/user/create")]
        void Create(User user);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/user/edit")]
        void Edit(User user);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/user/delete/{id}")]
        void Delete(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/user/get/{id}")]
        User GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "api/user/getall")]
        IEnumerable<User> GetAll();
    }
}
