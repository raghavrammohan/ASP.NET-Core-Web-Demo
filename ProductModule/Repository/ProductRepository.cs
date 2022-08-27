using Common.Repository;

namespace ProductModule.Repository;

public class ProductRepository : GenericRepository<Models.Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {

    }

}