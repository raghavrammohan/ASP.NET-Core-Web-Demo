using Common.UOW;
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
            /*ChangeTracker changeTracker = _unitOfWork.GetChangeTracker();
            var entries = changeTracker.Entries<Product>().Where(e => e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                if (entry.Property("ProductName").IsModified)
                    Console.WriteLine("------------------ Name is Modified -----------------");
            }*/

            var modifiedEntries = _unitOfWork.EntityChangeTracker.GetModifiedEntries<Product>("ProductName");
            if (modifiedEntries.Count > 0)
                Console.WriteLine("Product Name Changed");
            Console.WriteLine(modifiedEntries.ToString());
        }
    }
}
