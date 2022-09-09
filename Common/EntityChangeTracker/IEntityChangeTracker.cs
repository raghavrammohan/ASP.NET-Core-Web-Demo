using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Common.EntityChangeTracker
{
    public interface IEntityChangeTracker
    {
        List<EntityEntry<T>> GetModifiedEntries<T>(string propertyName = null) where T : class;
    }
}
