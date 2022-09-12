using ProductModule.Models;
using ProductModule.Repository;

namespace ProductModule.RepositoryManager
{
    public class ProductRepositoryManager : Common.UOW.RepositoryManager.RepositoryManager
    {
        public ProductRepositoryManager(IProductRepository productRepository)
        {
            RegisterRepository<IProductRepository, Product>(productRepository);
        }
    }
}
