namespace RelationshipMonitor.DAL.Repositories.Abstract
{
    public interface IEntityRepository
    {
        void Delete(int id);

        void Save(); 
    }
}