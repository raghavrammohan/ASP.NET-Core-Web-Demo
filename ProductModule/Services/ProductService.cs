using AutoMapper;
using Common.DataAccessManager;
using Common.Repository;
using Common.UOW;
using ProductClient.DTO;
using ProductModule.EntityProcessor;
using ProductModule.Models;
using ProductModule.Repository;
using System.Text.Json.Nodes;

namespace ProductModule.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductEntityProcessor _entityProcessor;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, ProductEntityProcessor entityProcessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _entityProcessor = entityProcessor;
        }

        public ProductDTO createProduct(ProductDTO productDTO)
        {
            Console.WriteLine("Saving Products using ProductService");
            Product product = _mapper.Map<Product>(productDTO);

            _unitOfWork.Start();
            // TODO: Lose the param when trying to get the repository from the dict
            _unitOfWork.GetDataAccessManager().GetRepository<IProductRepository>(typeof(IProductRepository)).Add(product);
            _unitOfWork.Complete();
            /*_unitOfWork.Execute(dam =>
            {
                dam.GetRepository<IProductRepository>(typeof(IProductRepository)).Add(product);
                Console.WriteLine("At the START of Product Service - Execute");
                _entityProcessor.processEntity(product);
                Console.WriteLine("At the END of Product Service - Execute");
            });*/

            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public void deleteProduct(string productId)
        {
            _unitOfWork.Start();
            //_unitOfWork.GetDataAccessManager().GetRepository<IProductRepository>(typeof(IProductRepository)).Remove();
            _unitOfWork.Complete();
        }

        public ProductDTO getProduct(string productId)
        {
            IProductRepository productRepository = _unitOfWork.GetDataAccessManager().GetRepository<IProductRepository>(typeof(IProductRepository));
            Product product = productRepository.GetById(productId);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public List<ProductDTO> searchProducts(JsonObject searchParams)
        {
            throw new NotImplementedException();
        }

        public ProductDTO updateProduct(ProductDTO productDTO)
        {
            Console.WriteLine("Updating Products using ProductService");
            Product product = _mapper.Map<Product>(productDTO);

            _unitOfWork.Start();
            // TODO: Lose the param when trying to get the repository from the dict
            _unitOfWork.GetDataAccessManager().GetRepository<IProductRepository>(typeof(IProductRepository)).Update(product);
            _unitOfWork.Complete();

            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }
    }
}
