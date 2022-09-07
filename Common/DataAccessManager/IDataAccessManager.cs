using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repository;
using Common.UOW;

namespace Common.DataAccessManager
{
    public interface IDataAccessManager
    {
        T GetRepository<T>(Type repositoryType); //where T : IGenericRepository<Type>;
        void RegisterRepository<T>(Type repositoryType, IGenericRepository<T> repository) where T : class;
    }
}
