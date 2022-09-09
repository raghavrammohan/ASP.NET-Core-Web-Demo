using Common.EntityChangeTracker;
using Common.OperationContext;
using Common.RepositoryManager;

namespace Common.UOW
{
    public interface IUnitOfWork
    {
        void Start();
        Task<int> Complete();
        bool IsOuterMostLevel();
        IRepositoryManager RepositoryManager { get; }
        IOperationContext OperationContext { get; }
        IEntityChangeTracker EntityChangeTracker { get; }
        void Execute(Action<IRepositoryManager> action);
        //ChangeTracker GetChangeTracker();
    }
}
