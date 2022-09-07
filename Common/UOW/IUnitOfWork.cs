using Common.DataAccessManager;
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
        void Complete();
        bool IsOuterMostLevel();
        IDataAccessManager GetDataAccessManager();
        void Execute(Action<IDataAccessManager> action);
    }
}
