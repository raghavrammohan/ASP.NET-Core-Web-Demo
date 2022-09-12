using Common.UOW.EntityChangeTracker;
using Common.UOW.OperationContext;
using Common.UOW.RepositoryManager;

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
