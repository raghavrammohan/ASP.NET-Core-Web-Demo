using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repository;
using Common.UOW;

namespace Common.DataAccessManager
{
    public class DataAccessManagerBase : IDataAccessManager
    {
        private readonly Dictionary<Type, object> _reposDictionary = new Dictionary<Type, object>();

        //private readonly IUnitOfWork _unitOfWork;
        /*public DataAccessManagerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }*/

        public T GetRepository<T>(Type repositoryType)
        {
            _reposDictionary.TryGetValue(repositoryType, out object repository);
            return (T)repository;
        }

        /*public IUnitOfWork GetUnitOfWork()
        {
            return _unitOfWork;
        }*/

        public void RegisterRepository<T>(Type repositoryType, IGenericRepository<T> repository) where T : class
        {
            _reposDictionary.TryAdd(repositoryType, repository);
        }
    }
}
