using Common.Repository;

namespace Common.UOW.RepositoryManager
{
    public interface IRepositoryManager
    {
        T GetRepository<T, E>() where T : IGenericRepository<E> where E : class;
        void RegisterRepository<T, E>(IGenericRepository<E> repository) where T : IGenericRepository<E> where E : class;
    }
}
