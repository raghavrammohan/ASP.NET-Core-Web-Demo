using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductModule.Repository;

public interface IUnitOfWork : IDisposable
{
    void Begin();
    IProductRepository Products { get; }
    ChangeTracker ChangeTracker();
    int Complete();
}
