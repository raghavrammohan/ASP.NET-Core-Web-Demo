using Common.Repository;
using Microsoft.EntityFrameworkCore;
using ProductModule.Models;

namespace ProductModule.Repository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {

    }

}