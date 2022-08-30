using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductModule;
using ProductModule.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Products = new ProductRepository(_context);
    }
    public IProductRepository Products { get; private set; }
    public int Complete()
    {
        return _context.SaveChanges();
    }
    public ChangeTracker ChangeTracker()
    {
        return _context.ChangeTracker;
    }
    public void Dispose()
    {
        //Dispose nestingLevel == 0;
        //if (nestingLevel == 0)
            // this.Complete();
        _context.Dispose();
    }

    public void Begin()
    {
        // Increment nesting level 
        throw new NotImplementedException();
    }
}