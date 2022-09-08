using Common.DataAccessManager;
using Common.UOW;
using Microsoft.EntityFrameworkCore;
using ProductModule.Models;
using ProductModule.Repository;

namespace ProductModule.DataAccessManager
{
    public class ProductRepositoryManager : RepositoryManager
    {
        public ProductRepositoryManager(IProductRepository productRepository)
        {
            RegisterRepository<IProductRepository, Product>(productRepository);
        }
    }
}
