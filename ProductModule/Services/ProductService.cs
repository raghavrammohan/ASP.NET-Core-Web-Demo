using AutoMapper;
using ProductClient.DTO;
using ProductModule.Repository;
using System.Text.Json.Nodes;

namespace ProductModule.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public ProductDTO createProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public void deleteProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public ProductDTO getProduct(string productId)
        {
            Models.Product product = _productRepository.GetById(productId);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public List<ProductDTO> searchProducts(JsonObject searchParams)
        {
            throw new NotImplementedException();
        }

        public ProductDTO updateProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
