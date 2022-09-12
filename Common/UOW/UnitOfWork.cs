using Common.UOW.EntityChangeTracker;
using Common.UOW.OperationContext;
using Common.UOW.RepositoryManager;
using Microsoft.EntityFrameworkCore;

namespace Common.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private int _nestingLevel = 0;
        private readonly DbContext _dbContext;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IOperationContext _operationContext;
        private readonly IEntityChangeTracker _entityChangeTracker;

        public UnitOfWork(DbContext context, IRepositoryManager repositoryManager, IOperationContext operationContext, IEntityChangeTracker entityChangeTracker)
        {
            _dbContext = context;
            _repositoryManager = repositoryManager;
            _operationContext = operationContext;
            _entityChangeTracker = entityChangeTracker;
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
