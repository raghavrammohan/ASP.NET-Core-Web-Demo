using Common.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductModule.Models;

namespace ProductModule.EntityProcessor
{
    public class ProductEntityProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductEntityProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void processEntity(Product entity)
        {
            /*
            ChangeTracker changeTracker = _unitOfWork.ChangeTracker();
            var entries = changeTracker.Entries<Product>().Where(e => e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                var modifiedProps = entry.Properties.Where(prop => prop.IsModified);
                Console.WriteLine("---------------{0}", modifiedProps.Select(p => p.Metadata));
            }
            */
        }
    }
}
