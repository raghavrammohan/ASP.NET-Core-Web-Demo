using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityChangeTracker
{
    public interface IEntityChangeTracker
    {
        List<EntityEntry<T>> GetModifiedEntries<T>(string propertyName = null) where T : class;
    }
}
