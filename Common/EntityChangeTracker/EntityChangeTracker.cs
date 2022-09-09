using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Common.EntityChangeTracker
{
    public class EntityChangeTracker : IEntityChangeTracker
    {
        private readonly DbContext _dbContext;
        public EntityChangeTracker(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<EntityEntry<T>> GetModifiedEntries<T>(string propertyName = null) where T : class
        {
            return _dbContext.ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Modified
                        && ((propertyName != null && e.Property(propertyName).IsModified) || propertyName == null)).ToList();

        }
    }
}
