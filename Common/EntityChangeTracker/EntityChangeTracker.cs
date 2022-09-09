using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
