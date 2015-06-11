using System.Data.Entity;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.DAL.Repositories
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("EFDbConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
