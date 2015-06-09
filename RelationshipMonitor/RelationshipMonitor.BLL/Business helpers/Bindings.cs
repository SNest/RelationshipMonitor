using Ninject.Modules;
using RelationshipMonitor.DAL.Repositories.Abstract;
using RelationshipMonitor.DAL.Repositories.Concrete;

namespace RelationshipMonitor.BLL.Business_helpers
{
    class Bindings : NinjectModule
    {
       public override void Load()
        {
            Bind<IActivityRepository>().To<EFActivityRepository>();
            Bind<IEventRepository>().To<EFEventRepository>();
            Bind<IRelationRepository>().To<EFRelationRepository>();
            Bind<IUserRepository>().To<EFUserRepository>();
        }
    }
}
