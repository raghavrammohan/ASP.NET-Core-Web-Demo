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
        private IProductRepository _productRepository => _unitOfWork.GetRepositoryManager().GetRepository<IProductRepository, Product>();

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, ProductEntityProcessor entityProcessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _entityProcessor = entityProcessor;
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO productDTO)
        {
            Console.WriteLine("Saving Products using ProductService");
            Product product = _mapper.Map<Product>(productDTO);

            _unitOfWork.Start();
            _productRepository.Add(product);
            _entityProcessor.processEntity(product);
            await _unitOfWork.Complete();
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

        public async Task DeleteProduct(string productId)
        {
            _unitOfWork.Start();
            Product product = new Product() { ProductId = productId };
            _productRepository.Remove(product);
            await _unitOfWork.Complete();
        }

        public async Task<ProductDTO> GetProduct(string productId)
        {
            Product product = await _productRepository.GetById(productId);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public async Task<List<ProductDTO>> SearchProducts(JsonObject searchParams)
        {
            List<Product> products = await _productRepository.GetAll();
            List<ProductDTO> results = new List<ProductDTO>();
            for (int i = 0; i < products.Count; i++)
            {
                results.Add(_mapper.Map<ProductDTO>(products[i]));
            }
            return results;
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO productDTO)
        {
            Console.WriteLine("Updating Products using ProductService");
            Product product = _mapper.Map<Product>(productDTO);

            _unitOfWork.Start();
            await _productRepository.Update(product, product.ProductId);
            _entityProcessor.processEntity(product);
            await _unitOfWork.Complete();

            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }
    }
}
