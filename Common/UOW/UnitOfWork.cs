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
        private readonly IDataAccessManager _dataAccessManager;
        // TODO: Operation Context

        public UnitOfWork(DbContext context, IDataAccessManager dataAccessManager)
        {
            _dbContext = context;
            _dataAccessManager = dataAccessManager;
        }

        public void Complete()
        {
            _nestingLevel--;
            if (IsOuterMostLevel())
                _dbContext.SaveChanges();
        }

        public bool IsOuterMostLevel()
        {
            return _nestingLevel == 0;
        }

        public void Start()
        {
            _nestingLevel++;
        }

        public IDataAccessManager GetDataAccessManager()
        {
            return _dataAccessManager;
        }

        public void Execute(Action<IDataAccessManager> action)
        {
            Console.WriteLine("In");
            this.Start();
            action.Invoke(_dataAccessManager);
            this.Complete();
            Console.WriteLine("Out");
        }
    }
}
