using Common.Repository;
using ProductModule.Models;

namespace ProductModule.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void Update(Product product);
    }
}
