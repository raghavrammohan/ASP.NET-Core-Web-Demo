using Common.RepositoryManager;
using Common.UOW;
using Microsoft.EntityFrameworkCore;
using ProductModule.Models;
using ProductModule.Repository;

namespace ProductModule.RepositoryManager
{
    public class ProductRepositoryManager : Common.RepositoryManager.RepositoryManager
    {
        public ProductRepositoryManager(IProductRepository productRepository)
        {
            RegisterRepository<IProductRepository, Product>(productRepository);
        }
    }
}
