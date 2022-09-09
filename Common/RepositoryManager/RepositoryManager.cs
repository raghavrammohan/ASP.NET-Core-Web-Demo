using Common.Repository;

namespace Common.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Dictionary<Type, object> _reposDictionary = new Dictionary<Type, object>();

        public T GetRepository<T, E>() where T : IGenericRepository<E> where E : class
        {
            _reposDictionary.TryGetValue(typeof(T), out object repository);
            return (T)repository;
        }

        public void RegisterRepository<T, E>(IGenericRepository<E> repository) where T : IGenericRepository<E> where E : class
        {
            _reposDictionary.TryAdd(typeof(T), repository);
        }
    }
}
