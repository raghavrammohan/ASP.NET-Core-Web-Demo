using Common.EntityChangeTracker;
using Common.OperationContext;
using Common.RepositoryManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Common.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private int _nestingLevel = 0;
        private readonly DbContext _dbContext;
        private readonly IRepositoryManager _repositoryManager;
        private IOperationContext _operationContext;
        private IEntityChangeTracker _entityChangeTracker;

        public UnitOfWork(DbContext context, IRepositoryManager repositoryManager)
        {
            _dbContext = context;
            _repositoryManager = repositoryManager;
            _operationContext = new OperationContext.OperationContext();
            _entityChangeTracker = new EntityChangeTracker.EntityChangeTracker(context);
        }

        public async Task<int> Complete()
        {
            _nestingLevel--;
            if (IsOuterMostLevel())
            {
                _operationContext.ClearContext();
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public bool IsOuterMostLevel() => _nestingLevel == 0;

        public void Start() => _nestingLevel++;

        public IRepositoryManager RepositoryManager => _repositoryManager;

        public IOperationContext OperationContext => _operationContext;

        public IEntityChangeTracker EntityChangeTracker => _entityChangeTracker;

        public void Execute(Action<IRepositoryManager> action)
        {
            Console.WriteLine("In");
            this.Start();
            action.Invoke(_repositoryManager);
            this.Complete();
            Console.WriteLine("Out");
        }

        //public ChangeTracker GetChangeTracker() => _dbContext.ChangeTracker;
    }
}
