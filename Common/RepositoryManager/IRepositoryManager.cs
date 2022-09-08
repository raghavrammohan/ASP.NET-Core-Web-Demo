using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repository;
using Common.UOW;

namespace Common.RepositoryManager
{
    public interface IRepositoryManager
    {
        T GetRepository<T, E>() where T : IGenericRepository<E> where E : class;
        void RegisterRepository<T, E>(IGenericRepository<E> repository) where T : IGenericRepository<E> where E : class;
    }
}
