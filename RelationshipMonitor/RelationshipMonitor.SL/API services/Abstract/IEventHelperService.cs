using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RelationshipMonitor.SL.API_services.Abstract
{
    [ServiceContract]
    public interface IEventHelperService
    {
        [OperationContract]
        void DoWork();
    }
}
