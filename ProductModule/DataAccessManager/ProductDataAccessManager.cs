using Common.DataAccessManager;
using Common.UOW;
using Microsoft.EntityFrameworkCore;
using ProductModule.Repository;

namespace ProductModule.DataAccessManager
{
    public class ProductDataAccessManager : DataAccessManagerBase
    {
        public ProductDataAccessManager(IProductRepository productRepository)
        {
            RegisterRepository(typeof(IProductRepository), productRepository);
        }
    }
}
