using Common.DataAccessManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private int _nestingLevel = 0;
        private readonly DbContext _dbContext;
        private readonly IRepositoryManager _repositoryManager;
        // TODO: Operation Context

        public UnitOfWork(DbContext context, IRepositoryManager repositoryManager)
        {
            _dbContext = context;
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> Complete()
        {
            _nestingLevel--;
            if (IsOuterMostLevel())
                await _dbContext.SaveChangesAsync();
            return true;
        }

        public bool IsOuterMostLevel()
        {
            return _nestingLevel == 0;
        }

        public void Start()
        {
            _nestingLevel++;
        }

        public IRepositoryManager GetRepositoryManager()
        {
            return _repositoryManager;
        }

        public void Execute(Action<IRepositoryManager> action)
        {
            Console.WriteLine("In");
            this.Start();
            action.Invoke(_repositoryManager);
            this.Complete();
            Console.WriteLine("Out");
        }
    }
}
