using Common.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UOW
{
    public interface IUnitOfWork
    {
        void Start();
        Task<int> Complete();
        bool IsOuterMostLevel();
        IRepositoryManager GetRepositoryManager();
        void Execute(Action<IRepositoryManager> action);
    }
}
